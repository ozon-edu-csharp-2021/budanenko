using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest
{
    public class AddMerchPackRequestCommand : IRequest<Unit>
    {
        public MerchType MerchPack { get; set; }
        public long EmployeeId { get; set; }
    }
}