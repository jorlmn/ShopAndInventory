using System.Collections.Generic;
using UnityEngine;

namespace JOR.Entities
{
    public class Vendor : MonoBehaviour
    {
        private InventoryData _inventory;

        public InventoryData Inventory => _inventory;

        public void Init(List<ItemData> vendorList)
        {
            _inventory = new InventoryData(vendorList);
        }
    }
}
