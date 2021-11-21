using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepositoryOld : IMerchPackRepositoryOld
    {
        private IMerchPackRepositoryOld _merchPackRepositoryOldImplementation;

        public Task<MerchPackTypeOld> GetByIdAsync(MerchTypeOld id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Enumeration.GetAll<MerchPackTypeOld>().Single(x => x.Id == (int)id));
        }

        public IUnitOfWork UnitOfWork { get; }
        public Task<MerchPackTypeOld> CreateAsync(MerchPackTypeOld itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPackTypeOld> UpdateAsync(MerchPackTypeOld itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}