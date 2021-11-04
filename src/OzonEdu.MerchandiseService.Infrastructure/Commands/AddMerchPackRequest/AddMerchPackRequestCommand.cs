using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest
{
    public class AddMerchPackRequestCommand : IRequest<MerchPackRequest>
    {
        public MerchType MerchPack { get; set; }
        public long EmployeeId { get; set; }
    }
}