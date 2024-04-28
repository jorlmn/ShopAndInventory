using System.Collections.Generic;
using UnityEngine;

namespace JOR.Shared
{
    public static class RandomUtils
    {
        public static int GetRandomValue(this Vector2Int range)
        {
            return Random.Range(range.x, range.y + 1);
        }

        public static T GetRandomValue<T>(this List<T> collection)
        {
            return collection[Random.Range(0, collection.Count - 1)];
        }
    }
}
