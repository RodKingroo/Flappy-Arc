using Tsuki.Framework.Core.IO;
using Tsuki.Framework.Core.Graphics;

namespace Tsuki.Framework.Core
{
    public abstract class Game
    {
        public Resource<byte[]>? Resources { get; set; }

        protected virtual TextureFilteringMode DefaultTextureFilteringMode => TextureFilteringMode.Linear;


    }
}
