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
/*
            var isPreviouslyReceived = employee.IsPreviouslyReceived(request.MerchPack);
            if (isPreviouslyReceived)
                throw new Exception("Данный мерч пак уже выдан сотруднику");
*/
            // Создание запроса на выдачу мерча
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.New,
                merchPackType,
                employeeId,
                clothingSize,
                email
            );

            var resultCreate = await _merchPackRequestRepository.CreateAsync(merchPackRequest, cancellationToken);

            return resultCreate.MerchPackRequestId!.Value;
        }
    }
}