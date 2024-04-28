using JOR.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace JOR.GameManager
{
    public class DataModelCollection : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> _itemSOs;

        public List<ItemSO> ItemSOs => _itemSOs;

        public void Init() { }
    }
}
