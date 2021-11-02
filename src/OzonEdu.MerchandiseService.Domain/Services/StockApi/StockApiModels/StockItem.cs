namespace OzonEdu.MerchandiseService.Domain.Services.StockApi.StockApiModels
{
    public class StockItem
    {
        public StockItem(long skuId, string itemName, int quantity, int itemType)
        {
            SkuId = skuId;
            ItemName = itemName;
            Quantity = quantity;
            ItemType = itemType;
        }

        public long SkuId { get; }
        
        public int ItemType { get; }
        
        public string ItemName { get; }
        
        public int Quantity { get; }
    }
}