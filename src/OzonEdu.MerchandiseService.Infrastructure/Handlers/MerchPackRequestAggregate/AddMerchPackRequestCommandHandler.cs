using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class AddMerchPackRequestCommandHandler : IRequestHandler<AddMerchPackRequestCommand, MerchPackRequest>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchPackRequestRepository _merchPackRequestRepository;

        public AddMerchPackRequestCommandHandler(
            IEmployeeRepository employeeRepository,
            IMerchPackRequestRepository merchPackRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _merchPackRequestRepository = merchPackRequestRepository;
        }

        public async Task<MerchPackRequest> Handle(AddMerchPackRequestCommand request, CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(request.EmployeeId);
            var employee = await _employeeRepository.FindByIdAsync(employeeId, cancellationToken);

            var isPreviouslyReceived = employee.IsPreviouslyReceived(request.MerchPack);
            if (isPreviouslyReceived)
                throw new Exception("Данный мерч пак уже выдан сотруднику");

            // Создание запроса на выдачу мерча
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.New,
                request.MerchPack,
                employeeId
            );

            // var resultCreate = await _merchPackRequestRepository.CreateAsync(merchPackRequest, cancellationToken);
            // var resultSave = await _merchPackRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return resultCreate;
        }
    }
}