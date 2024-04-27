using JOR.Entities;
using JOR.UI;
using System;
using UnityEngine;

namespace JOR.GameManager
{
    public class InventoryScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;
        [SerializeField] private ListController<ItemDataView, ItemData> _inventoryList;

        private InventoryData _currentInspectedInventory;

        public event Action<ItemData, bool> OnSubmit;

        public bool IsOpen { get; private set; }

        public virtual void Init()
        {
            _inventoryList.Init();
            _inventoryList.OnSubmit += OnSubmitView;
        }

        public virtual void Open(InventoryData inventory)
        {
            IsOpen = true;
            _currentInspectedInventory = inventory;
            RefreshInventory();

            _inventoryPanel.SetActive(true);
            _currentInspectedInventory.OnUpdateInventory += RefreshInventory;
        }

        public virtual void Close()
        {
            IsOpen = false;
            _inventoryPanel.SetActive(false);
            _inventoryList.ClearList();

            _currentInspectedInventory.OnUpdateInventory -= RefreshInventory;
            _currentInspectedInventory = null;
        }

        protected virtual void OnSubmitView(ItemData data, bool leftClick) => OnSubmit?.Invoke(data, leftClick);

        private void RefreshInventory()
        {
            _inventoryList.RefreshList(_currentInspectedInventory.CurrentInventory);
        }
    }
}
