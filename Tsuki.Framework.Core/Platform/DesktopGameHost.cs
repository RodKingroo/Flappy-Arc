using OpenTK.Windowing.Desktop;

namespace Tsuki.Framework.Core.Platform
{
    public class DesktopGameHost : GameHost
    {
        public DesktopGameHost(NativeWindowSettings nativeWindowSettings, GameWindowSettings gameWindowSettings) : base(nativeWindowSettings, gameWindowSettings)
        {
        }
    }
}
