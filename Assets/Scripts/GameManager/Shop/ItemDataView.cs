using UnityEngine;
using JOR.Entities;
using JOR.UI;
using UnityEngine.UI;

namespace JOR.GameManager
{
    public class ItemDataView : ItemView<ItemData>
    {
        [SerializeField] private Image _itemIcon;

        public override void Populate(ItemData data)
        {
            _itemIcon.gameObject.SetActive(true);
            _itemIcon.sprite = data.ItemProperties.Icon;
            base.Populate(data);
        }

        public override void Dispose()
        {
            _itemIcon.gameObject.SetActive(false);
            _itemIcon.sprite = null;
            base.Dispose();
        }
    }
}
