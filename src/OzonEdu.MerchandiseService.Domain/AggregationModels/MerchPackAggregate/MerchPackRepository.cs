using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPackRepository : IMerchPackRepository
    {
        private IMerchPackRepository _merchPackRepositoryImplementation;

        public Task<MerchPackType> GetByIdAsync(MerchType id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Enumeration.GetAll<MerchPackType>().Single(x => x.Id == (int)id));
        }

        public IUnitOfWork UnitOfWork { get; }
        public Task<MerchPackType> CreateAsync(MerchPackType itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPackType> UpdateAsync(MerchPackType itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}