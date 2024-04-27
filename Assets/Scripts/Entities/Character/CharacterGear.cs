using UnityEngine;
using System;

namespace JOR.Entities.Character
{
    [Serializable]
    public class CharacterGear : CharacterModule
    {
        [SerializeField] private SpriteRenderer _headGear;
        [SerializeField] private SpriteRenderer _bodyGear;

        private CharacterInventory Inventory => _controller.Inventory;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            Inventory.OnUpdateGear += RefreshGear;
        }

        public override void Dispose()
        {
            base.Dispose();
            Inventory.OnUpdateGear -= RefreshGear;
        }

        private void RefreshGear()
        {
            _headGear.sprite = Inventory.HeadGear?.ItemProperties.Icon;
            _bodyGear.sprite = Inventory.BodyGear?.ItemProperties.Icon;
        }
    }
}
