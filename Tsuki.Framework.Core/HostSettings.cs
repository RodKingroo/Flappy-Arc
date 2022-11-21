namespace Tsuki.Framework.Core
{
    public class HostSettings
    {
        public static HostSettings Default = new();

        public bool IsMultiThreaded { get; set; } = false;
        public double RenderFrequency { get; set; } = 0.0;
        public double UpdateFrequency { get; set; } = 0.0;


    }
}
