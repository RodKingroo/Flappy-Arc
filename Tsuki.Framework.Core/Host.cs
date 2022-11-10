using OpenTK.Windowing.Desktop;
using Tsuki.Framework.Core.Platform;

namespace Tsuki.Framework.Core
{
    public static class Host
    {
        public static DesktopGameHost GetSuitableDeskHost (NativeWindowSettings settings, GameWindowSettings gameWindowSettings)
        {
            switch (RuntimeInfo.OS)
            {
                case RuntimeInfo.Platform.Windows:
                    return new WindowsGameHost(settings, gameWindowSettings);
                /* На будующее, вдруг ещё займусь этим =P */
                /* case RuntimeInfo.Platform.Android:
                       return new AndroidGameHost(settings, gameWindowSettings)
                   case RuntimeInfo.Platform.Android:
                       return new AndroidGameHost(settings, gameWindowSettings)*/
                default:
                    throw new InvalidOperationException($"Unknown operating system ({RuntimeInfo.OS}).");
            }
        }

    }
}
