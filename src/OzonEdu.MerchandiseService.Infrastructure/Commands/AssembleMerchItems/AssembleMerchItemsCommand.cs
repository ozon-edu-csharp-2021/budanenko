using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AssembleMerchItems
{
    public class AssembleMerchItemsCommand : IRequest<Unit>
    {
        public MerchPackRequest MerchPackRequest { get; set; }
    }
}