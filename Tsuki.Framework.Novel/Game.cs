using Tsuki.Framework.Novel.IO;
using Tsuki.Framework.Novel.Graphics;

namespace Tsuki.Framework.Novel
{
    public abstract class Game
    {
        public Resource<byte[]>? Resources { get; set; }

        protected virtual TextureFilteringMode DefaultTextureFilteringMode => TextureFilteringMode.Linear;


    }
}
