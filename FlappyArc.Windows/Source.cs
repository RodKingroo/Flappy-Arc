using OpenTK.Windowing.Desktop;
using Tsuki.Framework.Core;

namespace FlappyArc.Windows
{
    public static class Source
    {
        [STAThread]
        private static void Main(string[] args)
        {
            GameHost host = new WindowsGameHost(NativeConfig.nativeWindowSettings, GameWindowSettings.Default);
            Game game = new FlappyGame();
            host.Run(game);
            
        }
    }
}
