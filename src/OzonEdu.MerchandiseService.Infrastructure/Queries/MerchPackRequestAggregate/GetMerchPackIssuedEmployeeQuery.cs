using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate
{
    public class GetMerchPackIssuedEmployeeQuery : IRequest<GetMerchPackIssuedEmployeeQueryResponse>
    {
        /// <summary>
        /// ИД сотрудника
        /// </summary>
        public long EmployeeId { get; set; }
    }
}