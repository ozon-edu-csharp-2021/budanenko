using System;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long merchItemId, long? responsibleManagerId, long employeeId, long? stockItemId/*, DateTime dateIssued*/)
        {
            MerchItemId = merchItemId;
            ResponsibleManagerId = responsibleManagerId;
            EmployeeId = employeeId;
            StockItemId = stockItemId;
           /* DateIssued = dateIssued;*/
        }

        public long MerchItemId { get; }
        
        public long? ResponsibleManagerId { get; }
        
        public long EmployeeId { get; }
        
        public long? StockItemId { get; }

       // public DateTime DateIssued { get; }
    }
}