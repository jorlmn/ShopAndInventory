using System;
using System.Collections.Generic;
using JOR.Shared;

namespace JOR.Entities
{
    public class InventoryData
    {
        private List<ItemData> _currentInventory = new List<ItemData>();

        public List<ItemData> CurrentInventory => _currentInventory;

        public event Action OnUpdateInventory;

        public InventoryData(List<ItemData> inventory)
        {
            _currentInventory = inventory;
        }

        public void AddToInventory(ItemData item)
        {
            _currentInventory.AddIfDoesntContains(item);
            OnUpdateInventory?.Invoke();
        }

        public void RemoveFromInventory(ItemData item)
        {
            _currentInventory.RemoveIfContains(item);
            OnUpdateInventory?.Invoke();
        }
    }
}
