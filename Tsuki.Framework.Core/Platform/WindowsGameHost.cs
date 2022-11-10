using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Tsuki.Framework.Core.Platform
{
    public class WindowsGameHost : DesktopGameHost
    {
        public WindowsGameHost(NativeWindowSettings settings, GameWindowSettings gameWindowSettings) : base(settings, gameWindowSettings)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (KeyboardState.IsKeyDown(Keys.Escape)) Close();

            base.OnUpdateFrame(e);
        }
    }
}
