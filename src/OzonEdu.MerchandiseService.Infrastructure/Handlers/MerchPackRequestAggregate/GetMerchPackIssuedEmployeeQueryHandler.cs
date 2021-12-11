using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Models;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate
{
    public class GetMerchPackIssuedEmployeeQueryHandler : IRequestHandler<GetMerchPackIssuedEmployeeQuery,
        GetMerchPackIssuedEmployeeQueryResponse>
    {
        private readonly IMerchPackRequestRepository _merchPackRequestRepository;

        public GetMerchPackIssuedEmployeeQueryHandler(
            IMerchPackRequestRepository merchPackRequestRepository)
        {
            _merchPackRequestRepository = merchPackRequestRepository;
        }

        public async Task<GetMerchPackIssuedEmployeeQueryResponse> Handle(GetMerchPackIssuedEmployeeQuery request,
            CancellationToken cancellationToken)
        {
            var merchPackRequests = await _merchPackRequestRepository.GetMerchPackRequestsByEmployeeIdAsync(
                new EmployeeId(request.EmployeeId),
                cancellationToken);
            return new GetMerchPackIssuedEmployeeQueryResponse
            {
                MerchPackTypes = merchPackRequests
                    .Where(x => Equals(x.RequestStatus, RequestStatus.Done))
                    .Select(x =>
                        new IssuedMerchPackTypeDto
                        {
                            MerchPackType = x.MerchPackType.Id,
                            IssuedDate = x.ChangeDate!.Value
                        }).ToList()
            };
        }
    }
}