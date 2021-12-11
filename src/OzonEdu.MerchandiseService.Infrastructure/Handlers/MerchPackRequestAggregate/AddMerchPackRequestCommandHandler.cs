using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class AddMerchPackRequestCommandHandler : IRequestHandler<AddMerchPackRequestCommand, long>
    {
        private readonly IMerchPackRequestRepository _merchPackRequestRepository;

        public AddMerchPackRequestCommandHandler(
            IMerchPackRequestRepository merchPackRequestRepository)
        {
            _merchPackRequestRepository = merchPackRequestRepository;
        }

        public async Task<long> Handle(AddMerchPackRequestCommand request, CancellationToken cancellationToken)
        {
            var merchPackType = Enumeration
                .GetAll<MerchPackType>()
                .FirstOrDefault(it => it.Id.Equals(request.MerchPackType));
            var employeeId = new EmployeeId(request.EmployeeId);
            var clothingSize = Enumeration
                .GetAll<ClothingSize>()
                .FirstOrDefault(it => it.Id.Equals(request.ClothingSize));
            var email = new Email(request.Email);
            var createDate = new CreateDate(DateTime.Now);

            var listAllMerchPackRequestsByEmployee =
                await _merchPackRequestRepository.GetMerchPackRequestsByEmployeeIdAsync(employeeId, cancellationToken);
            var isPreviouslyReceived = listAllMerchPackRequestsByEmployee.Any(x =>
            {
                var last12months = DateTime.Now.AddYears(-1);
                return x.MerchPackType.Id == merchPackType.Id && x.CreateDate.Value >= last12months;
            });
            if (isPreviouslyReceived)
                throw new Exception("Данный мерч пак уже выдан сотруднику");
            
            // Создание запроса на выдачу мерча
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.New,
                merchPackType,
                employeeId,
                clothingSize,
                email,
                createDate,
                null
            );

            var resultCreate = await _merchPackRequestRepository.CreateAsync(merchPackRequest, cancellationToken);

            return resultCreate.MerchPackRequestId!.Value;
        }
    }
}