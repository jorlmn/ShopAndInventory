using UnityEngine;
using JOR.Entities;
using TMPro;
using JOR.Entities.Character;

namespace JOR.GameManager
{
    public class CharacterInventoryScreen : InventoryScreen
    {
        [SerializeField] private TextMeshProUGUI _coinAmount;

        [SerializeField] private ItemDataView _headGearView;
        [SerializeField] private ItemDataView _bodyGearView;

        private CharacterInventory _characterInventory;
        private CharacterSystem _characterSystem;

        public void Open(CharacterSystem character)
        {
            _characterSystem = character;
            character.Stats.OnChangeWealth += UpdateWealth;

            _characterInventory = character.Inventory;
            _characterInventory.OnUpdateGear += UpdateGears;

            _headGearView.OnSubmit = SubmitOnHeadGear;
            _bodyGearView.OnSubmit = SubmitOnBodyGear;

            UpdateWealth(character.Stats.CurrentWealth);
            UpdateGears();
            base.Open(_characterInventory);
        }

        public override void Close()
        {
            _characterSystem.Stats.OnChangeWealth -= UpdateWealth;
            _characterSystem = null;

            _characterInventory.OnUpdateGear -= UpdateGears;
            _characterInventory = null;

            _headGearView.Dispose();
            _bodyGearView.Dispose();
            base.Close();
        }

        private void UpdateGears()
        {
            ItemData headGear = _characterInventory.HeadGear;
            ItemData bodyGear = _characterInventory.BodyGear;

            if (headGear == null)
            {
                _headGearView.Dispose();
            }
            else
            {
                _headGearView.Populate(headGear);
            }

            if (bodyGear == null)
            {
                _bodyGearView.Dispose();
            }
            else
            {
                _bodyGearView.Populate(bodyGear);
            }
        }

        private void UpdateWealth(int amount)
        {
            _coinAmount.text = amount.ToString();
        }

        private void SubmitOnHeadGear(ItemData currentGear, bool leftClick)
        {
            if (currentGear == null)
                return;

            _characterInventory.UnequipHeadGear();
        }

        private void SubmitOnBodyGear(ItemData currentGear, bool leftClick)
        {
            if (currentGear == null)
                return;

            _characterInventory.UnequipBodyGear();
        }

        protected override void OnSubmitView(ItemData data, bool leftClick)
        {
            if (leftClick)
            {
                base.OnSubmitView(data, leftClick);
                return;
            }

            if (data.Data.ItemType == ItemType.Head)
            {
                _characterInventory.EquipHeadGear(data);
            }
            else
            {
                _characterInventory.EquipBodyGear(data);
            }
        }
    }
}
