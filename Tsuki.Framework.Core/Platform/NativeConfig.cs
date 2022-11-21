using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace Tsuki.Framework.Core.Platform
{
    public static class NativeConfig
    {
        public static NativeWindowSettings nativeWindowSettings = new()
        {
            Size = new Vector2i(640, 320),
            Title = "Flappy Arc",
            Flags = ContextFlags.ForwardCompatible,
        };


    }
}
