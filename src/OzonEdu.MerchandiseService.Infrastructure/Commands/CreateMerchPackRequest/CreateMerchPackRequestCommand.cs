using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchPackRequest
{
    public class CreateMerchPackRequestCommand : IRequest<Unit>
    {
        public MerchPackType MerchPack { get; set; }
        public long EmployeeId { get; set; }
    }
}