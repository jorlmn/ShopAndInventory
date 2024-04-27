using UnityEngine;

namespace JOR.Entities
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Items/new ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        [SerializeField] private ItemType _itemType;

        public Sprite Icon => _icon;
        public int Cost => _cost;
        public ItemType ItemType => _itemType;
    }

    public enum ItemType
    {
        Head,
        Body
    }
}
