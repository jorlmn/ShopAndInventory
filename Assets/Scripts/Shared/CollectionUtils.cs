using System.Collections.Generic;

namespace JOR.Shared
{
    public static class CollectionUtils
    {
        public static void AddIfDoesntContains<TData>(this List<TData> collection, TData toAdd) where TData : class
        {
            if (!collection.Contains(toAdd))
                collection.Add(toAdd);
        }

        public static void RemoveIfContains<TData>(this List<TData> collection, TData toRemove) where TData : class
        {
            if (collection.Contains(toRemove))
                collection.Remove(toRemove);
        }
    }
}
