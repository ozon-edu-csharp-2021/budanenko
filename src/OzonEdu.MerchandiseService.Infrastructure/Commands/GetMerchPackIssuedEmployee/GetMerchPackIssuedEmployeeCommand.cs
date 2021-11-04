using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchPackIssuedEmployee
{
    public class GetMerchPackIssuedEmployeeCommand : IRequest<List<MerchType>>
    {
        public long EmployeeId { get; set; }
    }
}