using UnityEngine;
using JOR.Entities.Character;
using JOR.Entities;
using JOR.Inputs;

namespace JOR.GameManager
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionPrompt;
        [SerializeField] private CharacterInventoryScreen _characterInventoryScreen;
        [SerializeField] private InventoryScreen _vendorInventoryScreen;

        private CharacterSystem _playerCharacter;

        private Vendor _nearbyVendor;

        public void Init(CharacterSystem playerCharacter)
        {
            playerCharacter.Interactor.OnNearVendor += ApproachingVendor;
            _playerCharacter = playerCharacter;

            _characterInventoryScreen.Init();
            _vendorInventoryScreen.Init();

            _characterInventoryScreen.OnSubmit += TrySellItem;
            _vendorInventoryScreen.OnSubmit += TryBuyItem;

            _vendorInventoryScreen.OnToggle += ToggleVendorInventory;

            InputController.OnSubmit += TryOpenShop;
            InputController.OnToggleInventory += ToggleInventory;
            InputController.OnCancel += TryCloseShop;
        }

        public void Dispose()
        {
            InputController.OnSubmit -= TryOpenShop;
            InputController.OnToggleInventory -= ToggleInventory;
            InputController.OnCancel -= TryCloseShop;
        }

        private void TryOpenShop()
        {
            if (_nearbyVendor == null)
                return;

            if (!_characterInventoryScreen.IsOpen)
                _characterInventoryScreen.Open(_playerCharacter);

            if (!_vendorInventoryScreen.IsOpen)
                _vendorInventoryScreen.Open(_nearbyVendor.Inventory);
        }

        private void TryCloseShop()
        {
            if (_vendorInventoryScreen.IsOpen)
            {
                _vendorInventoryScreen.Close();
                return;
            }

            if (_characterInventoryScreen.IsOpen)
            {
                _characterInventoryScreen.Close();
                return;
            }
        }

        private void TryBuyItem(ItemData itemToBuy, bool leftClick)
        {
            if (!leftClick)
                return;

            int costToBuy = itemToBuy.Data.Cost;
            if (costToBuy > _playerCharacter.Stats.CurrentWealth)
                return;

            _playerCharacter.Stats.ChangeWealth(-costToBuy);
            _playerCharacter.Inventory.AddToInventory(itemToBuy);
            _nearbyVendor.Inventory.RemoveFromInventory(itemToBuy);
        }

        private void TrySellItem(ItemData itemToSell, bool leftClick)
        {
            if (!leftClick)
                return;

            _playerCharacter.Stats.ChangeWealth(itemToSell.Data.Cost);
            _playerCharacter.Inventory.RemoveFromInventory(itemToSell);
            _nearbyVendor.Inventory.AddToInventory(itemToSell);
        }

        private void ToggleInventory()
        {
            if (_characterInventoryScreen.IsOpen)
            {
                _characterInventoryScreen.Close();
                return;
            }

            _characterInventoryScreen.Open(_playerCharacter);
        }

        private void ToggleVendorInventory(bool enabled)
        {
            _playerCharacter.Movement.ToggleMovement(!enabled);
            _interactionPrompt.SetActive(!enabled && _nearbyVendor != null);
        }

        private void ApproachingVendor(Vendor vendor, bool isApproaching)
        {
            _nearbyVendor = isApproaching ? vendor : null;
            _interactionPrompt.SetActive(isApproaching);
        }
    }
}
