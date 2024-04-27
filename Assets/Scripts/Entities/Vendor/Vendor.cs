using System.Collections.Generic;
using UnityEngine;

namespace JOR.Entities
{
    public class Vendor : MonoBehaviour
    {
        private InventoryData _vendorInventory;

        public InventoryData VendorInventory => _vendorInventory;

        public void Init(List<ItemData> vendorList)
        {
            _vendorInventory = new InventoryData(vendorList);
        }
    }
}
