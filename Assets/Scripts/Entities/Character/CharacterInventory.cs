using System;
using System.Collections.Generic;

namespace JOR.Entities.Character
{
    public class CharacterInventory : InventoryData
    {
        private ItemData _headGear;
        private ItemData _bodyGear;

        public event Action OnUpdateGear;

        public ItemData HeadGear => _headGear;
        public ItemData BodyGear => _bodyGear;

        public CharacterInventory(ItemData headGear, ItemData bodyGear, List<ItemData> inventory) : base(inventory)
        {
            _headGear = headGear;
            _bodyGear = bodyGear;
        }

        public void EquipHeadGear(ItemData item)
        {
            if (_headGear != null)
                UnequipHeadGear();

            RemoveFromInventory(item);
            _headGear = item;

            TriggerGearUpdate();
        }

        public void EquipBodyGear(ItemData item)
        {
            if (_bodyGear != null)
                UnequipBodyGear();

            RemoveFromInventory(item);
            _bodyGear = item;

            TriggerGearUpdate();
        }

        public void UnequipHeadGear()
        {
            AddToInventory(_headGear);
            _headGear = null;
            TriggerGearUpdate();
        }

        public void UnequipBodyGear()
        {
            AddToInventory(_bodyGear);
            _bodyGear = null;
            TriggerGearUpdate();
        }

        private void TriggerGearUpdate() => OnUpdateGear?.Invoke();
    }
}
