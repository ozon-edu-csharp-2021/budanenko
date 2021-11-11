using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class MerchPackRequestRepository : IMerchPackRequestRepository
    {
        private readonly List<MerchPackRequest> MerchPackRequests = new List<MerchPackRequest>
        {
            new MerchPackRequest(new RequestNumber(1), RequestStatus.Done, MerchType.WelcomePack,
                new EmployeeId(28)),
            new MerchPackRequest(new RequestNumber(2), RequestStatus.Done, MerchType.ConferenceListenerPack,
                new EmployeeId(17)),
            new MerchPackRequest(new RequestNumber(3), RequestStatus.Done, MerchType.ProbationPeriodEndingPack,
                new EmployeeId(28)),
            new MerchPackRequest(new RequestNumber(4), RequestStatus.Done, MerchType.ConferenceSpeakerPack,
                new EmployeeId(7)),
            new MerchPackRequest(new RequestNumber(5), RequestStatus.Done, MerchType.VeteranPack,
                new EmployeeId(7)),
            new MerchPackRequest(new RequestNumber(6), RequestStatus.Done, MerchType.WelcomePack,
                new EmployeeId(83)),
            new MerchPackRequest(new RequestNumber(7), RequestStatus.Done, MerchType.ConferenceSpeakerPack,
                new EmployeeId(17)),
            new MerchPackRequest(new RequestNumber(8), RequestStatus.Denied, MerchType.ConferenceSpeakerPack,
                new EmployeeId(17)),
        };

        public IUnitOfWork UnitOfWork { get; }

        public Task<MerchPackRequest> CreateAsync(MerchPackRequest merchPackRequest,
            CancellationToken cancellationToken = default)
        {
            long maxRequestNumber = MerchPackRequests.Max(t => t.RequestNumber!.Value);
            maxRequestNumber++;
            merchPackRequest.SetRequestNumber(maxRequestNumber);
            MerchPackRequests.Add(merchPackRequest);

            return Task.FromResult(MerchPackRequests.Find(x => x.RequestNumber.Value == maxRequestNumber));
        }

        public Task<MerchPackRequest> UpdateAsync(MerchPackRequest itemToUpdate,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPackRequest?> FindByRequestNumberAsync(RequestNumber requestNumber,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(MerchPackRequests.Find(x => x.RequestNumber.Value == requestNumber.Value));
        }

        public Task<List<MerchPackRequest>> GetMerchPackRequestForAssembly(
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(MerchPackRequests
                .Where(s => new[] {RequestStatus.New, RequestStatus.InWork}.Contains(s.RequestStatus)).ToList());
        }
    }
}