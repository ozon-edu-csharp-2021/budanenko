using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class MerchItemStatus
    {
        public MerchItemStatus(MerchItemId? merchItemId, MerchItemType merchItemType, Status status)
        {
            MerchItemId = merchItemId;
            MerchItemType = merchItemType;
            Status = status;
        }
        
        public MerchItemStatus(MerchItemType merchItemType)
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