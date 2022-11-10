using OpenTK.Windowing.Desktop;


namespace Tsuki.Framework.Core.Platform
{
    public class DesktopGameHost : GameHost
    {

        public DesktopGameHost(NativeWindowSettings nativeWindowSettings, HostSettings hostSettings) : base(nativeWindowSettings, hostSettings)
        {
            IsMultiThreaded = hostSettings.IsMultiThreaded;
            RenderFrequency = hostSettings.RenderFrequency;
            UpdateFrequency = hostSettings.UpdateFrequency;
        }

        
    }
}
