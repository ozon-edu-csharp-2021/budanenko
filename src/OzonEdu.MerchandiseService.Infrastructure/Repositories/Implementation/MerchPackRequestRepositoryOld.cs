using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchPackRequestRepositoryOld : IMerchPackRequestRepository
    {
        // private readonly List<MerchPackRequest> MerchPackRequests = new List<MerchPackRequest>
        // {
        //     new MerchPackRequest(new MerchPackRequestId(1), RequestStatus.Done, MerchTypeOld.WelcomePack,
        //         new EmployeeId(28)),
        //     new MerchPackRequest(new MerchPackRequestId(2), RequestStatus.Done, MerchTypeOld.ConferenceListenerPack,
        //         new EmployeeId(17)),
        //     new MerchPackRequest(new MerchPackRequestId(3), RequestStatus.Done, MerchTypeOld.ProbationPeriodEndingPack,
        //         new EmployeeId(28)),
        //     new MerchPackRequest(new MerchPackRequestId(4), RequestStatus.Done, MerchTypeOld.ConferenceSpeakerPack,
        //         new EmployeeId(7)),
        //     new MerchPackRequest(new MerchPackRequestId(5), RequestStatus.Done, MerchTypeOld.VeteranPack,
        //         new EmployeeId(7)),
        //     new MerchPackRequest(new MerchPackRequestId(6), RequestStatus.Done, MerchTypeOld.WelcomePack,
        //         new EmployeeId(83)),
        //     new MerchPackRequest(new MerchPackRequestId(7), RequestStatus.Done, MerchTypeOld.ConferenceSpeakerPack,
        //         new EmployeeId(17)),
        //     new MerchPackRequest(new MerchPackRequestId(8), RequestStatus.Denied, MerchTypeOld.ConferenceSpeakerPack,
        //         new EmployeeId(17)),
        // };

        public IUnitOfWork UnitOfWork { get; }

/*
        public Task<MerchPackRequest> CreateAsync(MerchPackRequest merchPackRequest,
            CancellationToken cancellationToken = default)
        {
            long maxRequestNumber = MerchPackRequests.Max(t => t.MerchPackRequestId!.Value);
            maxRequestNumber++;
            merchPackRequest.SetRequestNumber(maxRequestNumber);
            MerchPackRequests.Add(merchPackRequest);

            return Task.FromResult(MerchPackRequests.Find(x => x.MerchPackRequestId.Value == maxRequestNumber));
        }

        public Task<MerchPackRequest> UpdateAsync(MerchPackRequest itemToUpdate,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPackRequest?> FindByRequestNumberAsync(MerchPackRequestId merchPackRequestId,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(MerchPackRequests.Find(x => x.MerchPackRequestId.Value == merchPackRequestId.Value));
        }

        public Task<List<MerchPackRequest>> GetMerchPackRequestForAssembly(
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(MerchPackRequests
                .Where(s => new[] {RequestStatus.New, RequestStatus.InWork}.Contains(s.RequestStatus)).ToList());
        }
 */
        public Task<MerchPackRequest> CreateAsync(MerchPackRequest recordToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPackRequest> UpdateStatusAsync(MerchPackRequest recordToUpdate,
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<MerchPackRequest>> GetMerchPackRequestForAssembly(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<MerchPackRequest>> GetMerchPackRequestsByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}