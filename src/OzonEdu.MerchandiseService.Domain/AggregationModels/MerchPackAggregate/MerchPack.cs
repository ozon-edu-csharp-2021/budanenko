using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class MerchPack : Entity
    {
        public MerchPackType Type { get; }

        public MerchPack(MerchPackType type)
        {
            Id = type.Id;
            Type = type;
        }
        
    }
}