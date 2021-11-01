using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchPackRequest;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class CreateMerchPacRequestCommandHandler : IRequestHandler<CreateMerchPackRequestCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerckPackRequestRepository _merckPackRequestRepository;

        public CreateMerchPacRequestCommandHandler(
            IEmployeeRepository employeeRepository,
            IMerckPackRequestRepository merckPackRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _merckPackRequestRepository = merckPackRequestRepository ??
                                          throw new ArgumentNullException($"{nameof(merckPackRequestRepository)}");
        }

        public async Task<Unit> Handle(CreateMerchPackRequestCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindByIdAsync(request.EmployeeId);
            var merchPackType = new MerchPackType(request.MerchPack);

            var isGiven = employee.IsGiven(merchPackType);

            if (isGiven)
                throw new Exception("Данный мерч пак уже выдан сотруднику");

            // Создание запроса на мерч
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.InWork,
                merchPackType,
                new EmployeeId(employee.EmployeeId)
            );

            await _merckPackRequestRepository.CreateAsync(merchPackRequest, cancellationToken);

            // взависимости от бизнесс процесса либо вызвать stock-api
            // Если stok-api ответил без ошибок
            // await _merckPackRequestRepository.UpdateStatus('Запрошено');

            await _merckPackRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}