using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItemOld : Entity
    {
        public MerchItemOld(
            MerchItemId merchItemId,
            Name name,
            MerchItemType merchItemType,
            ClothingSize size)
        {
            MerchItemId = merchItemId;
            Name = name;
            MerchItemType = merchItemType;
        }

        public MerchItemId MerchItemId { get; }

        public Name Name { get; }

        public MerchItemType MerchItemType { get; }
    }
}