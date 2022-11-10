using Tsuki.Framework.Novel;
using Tsuki.Framework.Core;
using Tsuki.Framework.Core.Platform;

namespace FlappyArc.Windows
{
    public static class Source
    {
        [STAThread]
        private static void Main(string[] args)
        {
            GameHost host = Host.GetSuitableDeskHost(NativeConfig.nativeWindowSettings, HostSettings.Default);
            Game game = new FlappyGame();
            host.Run(game);
            
        }
    }
}
