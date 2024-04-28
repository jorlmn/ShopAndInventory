using UnityEngine;
using JOR.Shared;
using JOR.Settings;

namespace JOR.Entities
{
    public class ConsumablesSpawner : MonoBehaviour
    {
        [SerializeField] private Consumable _consumablePrefab;
        [SerializeField] private Transform _consumableParent;

        [Header("Coins")]
        [SerializeField] private Sprite _coinSprite;

        private ObjectPool<Consumable> _consumablePool;

        public void Init()
        {
            _consumablePool = new MonoBehaviourObjectPool<Consumable>(_consumablePrefab, _consumableParent);

            int coinAmountToSpawn = GameConfig.CoinsToSpawn.GetRandomValue();

            for (int i = 0; i < coinAmountToSpawn; i++)
            {
                SpawnConsumable(ConsumableType.Coin, _coinSprite);
            }
        }

        private void SpawnConsumable(ConsumableType consumableType, Sprite sprite)
        {
            Vector2Int spawnArea = GameConfig.CoinSpawnArea;
            Vector2Int position = new Vector2Int(spawnArea.GetRandomValue(), spawnArea.GetRandomValue());

            Consumable consumable = _consumablePool.GetFromPool();
            consumable.Spawn(consumableType, sprite, position);
            consumable.OnConsumed += AfterConsume;
        }

        private void AfterConsume(Consumable consumable) => _consumablePool.ReturnToPool(consumable);
    }
}


