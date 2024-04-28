using JOR.Shared;
using System.Collections.Generic;
using UnityEngine;

namespace JOR.Entities
{
    public class Vendor : MonoBehaviour
    {
        private InventoryData _inventory;

        public InventoryData Inventory => _inventory;

        public void Init(List<ItemSO> possibleItems)
        {
            int itemsToCopy = 20;

            List<ItemData> vendorList = new List<ItemData>();

            if (possibleItems.Count > 0)
            {
                for (int i = 0; i < itemsToCopy; i++)
                {
                    ItemData itemData = new ItemData(possibleItems.GetRandomValue());
                    vendorList.Add(itemData);
                }
            }

            _inventory = new InventoryData(vendorList);
        }
    }
}
