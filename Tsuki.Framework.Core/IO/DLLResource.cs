using System.Reflection;


namespace Tsuki.Framework.Core.IO
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
