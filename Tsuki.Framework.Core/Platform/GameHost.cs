using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;


namespace Tsuki.Framework.Core.Platform
{
    public class GameHost : NativeWindow
    {
        private const double MaxFrequency = 500.0;

        public event Action? Load;
        public event Action? Unload;
        public event Action? RenderThreadStarted;

        public event Action<FrameEventArgs>? UpdateFrame;
        public event Action<FrameEventArgs>? RenderFrame;

        private readonly Stopwatch _watchRender = new();
        private readonly Stopwatch _watchUpdate = new();


        protected bool IsRunningSlowly { get; set; }

        private double _updateEpsilon;
        private double _renderFrequency;
        private double _updateFrequency;

        private Thread? _renderThread;

        public bool IsMultiThreaded { get; set; }

        public double RenderFrequency
        {
            get => _renderFrequency;
            set
            {
                switch (value)
                {
                    case <= 1.0:
                        _renderFrequency = 0.0;
                        break;
                    case <= MaxFrequency:
                        _renderFrequency = value;
                        break;
                    default:
                        Debug.Print("Target render frequency clamped to {0} Hz.", MaxFrequency);
                        _renderFrequency = MaxFrequency;
                        break;
                }
            }
        }

        public double RenderTime { get; set; }
        public double UpdateTime { get; set; }

        public double UpdateFrequency
        {
            get => _updateFrequency;
            set
            {
                switch (value)
                {
                    case < 1.0:
                        _updateFrequency = 0.0;
                        break;
                    case <= MaxFrequency:
                        _updateFrequency = value;
                        break;
                    default:
                        Debug.Print("Target render frequency clamped to {0} Hz.", MaxFrequency);
                        _updateFrequency = MaxFrequency;
                        break;
                }
            }
        }

        public HostSettings Settings { get; set; }
        public NativeWindowSettings NativeSettings { get;set; }

        public GameHost(NativeWindowSettings nativeWindowSettings, HostSettings hostSettings) : base(nativeWindowSettings)
        {
            Settings = hostSettings ?? new HostSettings();
            NativeSettings = nativeWindowSettings ?? new NativeWindowSettings();


        }

        public virtual void Run(Game game)
        {
            Context?.MakeCurrent();
            OnLoad();
            OnResize(new ResizeEventArgs(Size));

            Debug.Print("Entering main loop.");
            if (IsMultiThreaded)
            {
                Context?.MakeNoneCurrent();

                _renderThread = new Thread(StartRenderThread);
                _renderThread.Start();
            }

            _watchRender.Start();
            _watchUpdate.Start();

            OnSleep();
            OnUnload();
        }

        private unsafe void OnSleep()
        {
            while (GLFW.WindowShouldClose(WindowPtr) == false)
            {
                double timeToNextUpdateFrame = DispatchUpdateFrame();

                double sleepTime = timeToNextUpdateFrame;
                if (!IsMultiThreaded)
                {
                    double timeToNextRenderFrame = DispatchRenderFrame();
                    sleepTime = Math.Min(sleepTime, timeToNextRenderFrame);

                }

                if (sleepTime > 0) Thread.Sleep((int)Math.Floor(sleepTime * 1000));
            }
        }

        private unsafe void StartRenderThread()
        {
            Context?.MakeCurrent();

            OnRenderThreadStarted();
            _watchRender.Start();
            while (GLFW.WindowShouldClose(WindowPtr) == false) DispatchRenderFrame();

        }

        private double DispatchUpdateFrame()
        {
            var isRunningSlowlyRetries = 4;
            var elapsed = _watchUpdate.Elapsed.TotalMilliseconds;

            var updatePeriod = UpdateFrequency == 0 ? 0 : 1 / UpdateFrequency;

            while (elapsed > 0 && elapsed + _updateEpsilon >= updatePeriod)
            {
                ProcessInputEvents();
                ProcessWindowEvents(IsEventDriven);

                _watchUpdate.Restart();
                UpdateTime = elapsed;
                OnUpdateFrame(new FrameEventArgs(elapsed));

                _updateEpsilon += elapsed - updatePeriod;

                if (UpdateFrequency <= double.Epsilon) break;

                IsRunningSlowly = _updateEpsilon >= updatePeriod;

                if (IsRunningSlowly && --isRunningSlowlyRetries == 0)
                {
                    _updateEpsilon = 0;
                    break;
                }

                elapsed = _watchUpdate.Elapsed.TotalSeconds;
            }

            return UpdateFrequency == 0 ? 0 : updatePeriod - elapsed;
        }

        private double DispatchRenderFrame()
        {
            var elapsed = _watchRender.Elapsed.TotalSeconds;
            var renderPeriod = RenderFrequency == 0 ? 0 : 1 / RenderFrequency;
            if (elapsed > 0 && elapsed >= renderPeriod)
            {
                _watchRender.Restart();
                RenderTime = elapsed;
                OnRenderFrame(new FrameEventArgs(elapsed));

                if (VSync == VSyncMode.Adaptive) GLFW.SwapInterval(IsRunningSlowly ? 0 : 1);
            }

            return RenderFrequency == 0 ? 0 : renderPeriod - elapsed;
        }

        public override void Close() => base.Close();

        protected virtual void OnRenderThreadStarted() => RenderThreadStarted?.Invoke();

        protected virtual void OnLoad() => Load?.Invoke();
        protected virtual void OnUnload() => Unload?.Invoke();

        protected virtual void OnUpdateFrame(FrameEventArgs args) => UpdateFrame?.Invoke(args);
        protected virtual void OnRenderFrame(FrameEventArgs args) => RenderFrame?.Invoke(args);

    }
}
