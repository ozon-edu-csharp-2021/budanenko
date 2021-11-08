using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate
{
    public class GetMerchPackIssuedEmployeeQuery : IRequest<List<MerchType>>
    {
        public long EmployeeId { get; set; }
    }
}