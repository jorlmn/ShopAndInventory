using System;
using UnityEngine;

namespace JOR.Entities
{
    public class Consumable : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public event Action<Consumable> OnConsumed;

        public ConsumableType ConsumableType { get; private set; }

        public void Spawn(ConsumableType consumableType, Sprite sprite, Vector2 position)
        {
            ConsumableType = consumableType;
            transform.position = position;
            _spriteRenderer.sprite = sprite;
        }

        public void Consume()
        {
            OnConsumed?.Invoke(this);
            OnConsumed = null;
        }
    }

    public enum ConsumableType
    { 
        Coin   
    }
}
