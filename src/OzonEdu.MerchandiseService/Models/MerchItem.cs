namespace OzonEdu.MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long merchItemId, long? responsibleManagerId, long employeeId, long? stockItemId)
        {
            MerchItemId = merchItemId;
            ResponsibleManagerId = responsibleManagerId;
            EmployeeId = employeeId;
            StockItemId = stockItemId;
        }

        public long MerchItemId { get; }
        
        public long? ResponsibleManagerId { get; }
        
        public long EmployeeId { get; }
        
        public long? StockItemId { get; }

    }
}