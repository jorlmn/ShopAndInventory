using UnityEngine;

namespace JOR.Settings
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig/new GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Header("Player Config")]
        [SerializeField] private int _playerDefaultSpeed = 8;
        [SerializeField] private int _playerStartingWealth = 5;

        [Header("Misc Config")]
        [SerializeField] private Vector2Int _vendorItemsCount = new Vector2Int(15, 25);
        [SerializeField] private Vector2Int _coinsToSpawn = new Vector2Int(20, 30);
        [SerializeField] private Vector2Int _coinSpawnArea = new Vector2Int(-15, 15);

        private static GameConfig _instance;

        public void Init()
        {
            _instance = this;
        }

        public static int PlayerDefaultSpeed => _instance._playerDefaultSpeed;
        public static int PlayerStartingWealth => _instance._playerStartingWealth;
        public static Vector2Int VendorItemsCount => _instance._vendorItemsCount;
        public static Vector2Int CoinsToSpawn => _instance._coinsToSpawn;
        public static Vector2Int CoinSpawnArea => _instance._coinSpawnArea;
    }
}
