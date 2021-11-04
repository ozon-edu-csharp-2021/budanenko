using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchPackIssuedEmployee;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class GetMerchPackIssuedEmployeeCommandHandler : IRequestHandler<GetMerchPackIssuedEmployeeCommand, List<MerchType>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchPackRequestRepository _merchPackRequestRepository;

        public GetMerchPackIssuedEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IMerchPackRequestRepository merchPackRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _merchPackRequestRepository = merchPackRequestRepository;
        }

        public async Task<List<MerchType>> Handle(GetMerchPackIssuedEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(request.EmployeeId);
            var employeeMerchTypes = await _employeeRepository.GetEmployeeMerchTypes(employeeId, cancellationToken);
            return employeeMerchTypes;
        }
    }
}