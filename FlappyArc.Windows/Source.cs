using OpenTK.Windowing.Desktop;
using Tsuki.Framework.Core;
using Tsuki.Framework.Core.Platform;

namespace FlappyArc.Windows
{
    public static class Source
    {
        [STAThread]
        private static void Main(string[] args)
        {
            GameHost host = Host.GetSuitableDeskHost(NativeConfig.nativeWindowSettings, GameWindowSettings.Default);
            Game game = new FlappyGame();
            host.Run(game);
            
        }
    }
}
