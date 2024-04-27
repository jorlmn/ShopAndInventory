using UnityEngine;
using JOR.Shared;

namespace JOR.Entities.Consumables
{
    public class ConsumablesSpawner : MonoBehaviour
    {
        [SerializeField] private Consumable _consumablePrefab;
        [SerializeField] private Transform _consumableParent;
        [SerializeField] private Vector2Int _spawnRange;

        [Header("Coins")]
        [SerializeField] private Vector2Int _startingCoinAmount;
        [SerializeField] private Sprite _coinSprite;

        private ObjectPool<Consumable> _consumablePool;

        public void Init()
        {
            _consumablePool = new MonoBehaviourObjectPool<Consumable>(_consumablePrefab, _consumableParent);

            int coinAmountToSpawn = _startingCoinAmount.GetRandomValue();

            for (int i = 0; i < coinAmountToSpawn; i++)
            {
                SpawnConsumable(ConsumableType.Coin, _coinSprite);
            }
        }

        private void SpawnConsumable(ConsumableType consumableType, Sprite sprite)
        {
            Vector2Int position = new Vector2Int(_spawnRange.GetRandomValue(), _spawnRange.GetRandomValue());

            Consumable consumable = _consumablePool.GetFromPool();
            consumable.Spawn(consumableType, sprite, position);
            consumable.OnConsumed += AfterConsume;
        }

        private void AfterConsume(Consumable consumable) => _consumablePool.ReturnToPool(consumable);
    }
}


