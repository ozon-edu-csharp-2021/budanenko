using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.EmployeeAggregate
{
    public class GetMerchPackIssuedEmployeeQueryHandler : IRequestHandler<GetMerchPackIssuedEmployeeQuery, List<MerchTypeOld>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetMerchPackIssuedEmployeeQueryHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<MerchTypeOld>> Handle(GetMerchPackIssuedEmployeeQuery request,
            CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(request.EmployeeId);
            var employeeMerchTypes = await _employeeRepository.GetEmployeeMerchTypes(employeeId, cancellationToken);
            return employeeMerchTypes;
        }
    }
}