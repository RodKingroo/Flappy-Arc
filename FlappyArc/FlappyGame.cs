using Tsuki.Framework.Core;
using Tsuki.Framework.Core.IO;
using Tsuki.Framework.Core.Graphics;
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
