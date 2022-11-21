using System.Runtime.InteropServices;

namespace Tsuki.Framework.Core
{
    public static class RuntimeInfo
    {
        public static Platform OS { get; set; }

        static RuntimeInfo()
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) OS = Platform.Windows;
            else throw new InvalidOperationException("OS not correct"); 
        }

        public enum Platform
        {
            Windows,
            Android,
            Linux,

        }

    }
}
