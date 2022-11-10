using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Tsuki.Framework.Core.Platform
{
    public static class NativeConfig
    {
        public static readonly NativeWindowSettings nativeWindowSettings = new()
        {
            Size = new Vector2i(540, 320),
            Title = "Flappy Arc",
            Flags = ContextFlags.ForwardCompatible,
        };


    }
}
