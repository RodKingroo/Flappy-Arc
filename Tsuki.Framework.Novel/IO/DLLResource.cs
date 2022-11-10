using System.Reflection;


namespace Tsuki.Framework.Novel.IO
{
    public class DLLResource : IResource<byte[]>
    {
        private Assembly assembly;
        private string? prefix;

        public DLLResource(Assembly assembly)
        {
            this.assembly = assembly;
            prefix = assembly.GetName().Name;
        }


    }
}
