using UnityEngine;
using System;

namespace JOR.Entities.Character
{
    [Serializable]
    public class CharacterGear : CharacterModule
    {
        [SerializeField] private SpriteRenderer _headGear;
        [SerializeField] private SpriteRenderer _bodyGear;

        [Header("Default Appearance")]
        [SerializeField] private Sprite _defaultHead;
        [SerializeField] private Sprite _defaultBody;

        private CharacterInventory Inventory => _controller.Inventory;

        public override void Init(CharacterSystem controller)
        {
            base.Init(controller);
            Inventory.OnUpdateGear += RefreshGear;
            RefreshGear();
        }

        public override void Dispose()
        {
            base.Dispose();
            Inventory.OnUpdateGear -= RefreshGear;
        }

        private void RefreshGear()
        {
            _headGear.sprite = Inventory.HeadGear == null ? _defaultHead : Inventory.HeadGear.Data.Icon;
            _bodyGear.sprite = Inventory.BodyGear == null ? _defaultBody : Inventory.BodyGear.Data.Icon;
        }
    }
}
