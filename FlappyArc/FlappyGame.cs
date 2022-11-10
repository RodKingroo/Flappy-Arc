using Tsuki.Framework.Novel;
using Tsuki.Framework.Novel.IO;
using Tsuki.Framework.Novel.Graphics;
using FlappyArc.Resources;

namespace FlappyArc
{
    public class FlappyGameBase : Game
    {
        protected override TextureFilteringMode DefaultTextureFilteringMode => TextureFilteringMode.Nearest;

        private void load() => Resources?.AddStore(new DLLResource(FlappyArcRes.ResourceAssemply));
        
    }

    public class FlappyGame : FlappyGameBase
    {
        
    }
}
