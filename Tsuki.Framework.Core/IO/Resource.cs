

namespace Tsuki.Framework.Core.IO
{
    public class Resource<T> : IResource<T> where T : class
    {
        public List<IResource<T>> Stores { get; } = new();

        public virtual void AddStore(IResource<T> store)
        {
            lock (Stores) Stores.Add(store);
        }

    }
}
