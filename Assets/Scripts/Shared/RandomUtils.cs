using UnityEngine;

namespace JOR.Shared
{
    public static class RandomUtils
    {
        public static int GetRandomValue(this Vector2Int range)
        {
            return Random.Range(range.x, range.y + 1);
        }
    }
}
