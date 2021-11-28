using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class MerchItem
    {
        // public MerchItemStatus(MerchItemId? merchItemId, MerchItemType merchItemType, Status status)
        // {
        //     MerchItemId = merchItemId;
        //     MerchItemType = merchItemType;
        //     Status = status;
        // }
        
        public MerchItem(MerchItemType merchItemType)
        {
            MerchItemId = null;
            MerchItemType = merchItemType;
            Status = Status.New;
        }

        public MerchItemId? MerchItemId { get; set; }

        public MerchItemType MerchItemType { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        New = 1,
        Reserved = 2,
        WaitingDelivery = 3
    }
}