namespace JOR.Entities
{
    public class ItemData
    { 
        public ItemSO ItemProperties { get; }

        public ItemData(ItemSO itemSO) => ItemProperties = itemSO;
    }
}
