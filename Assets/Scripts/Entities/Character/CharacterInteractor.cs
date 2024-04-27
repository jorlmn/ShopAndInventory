using System;
using UnityEngine;
using JOR.Shared;

namespace JOR.Entities.Character
{
    [Serializable]
    public class CharacterInteractor : CharacterModule
    {
        [SerializeField] private WorldCollider _worldCollider;

        public event Action OnConsume;
        public event Action<Vendor, bool> OnNearVendor;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            _worldCollider.OnTriggerCollision += TriggeredCollision;
        }

        private void TriggeredCollision(Collider2D collider, bool entered)
        {
            if (entered && collider.TryGetComponent(out Consumable consumable) && consumable.ConsumableType == ConsumableType.Coin)
            {
                consumable.Consume();
                OnConsume?.Invoke();
                _controller.Stats.ChangeWealth(1);
                return;
            }

            if (collider.TryGetComponent(out Vendor vendor))
            {
                OnNearVendor?.Invoke(vendor, entered);
            }
        }

        public override void Dispose()
        {
            _worldCollider.OnTriggerCollision -= TriggeredCollision;
        }
    }
}
