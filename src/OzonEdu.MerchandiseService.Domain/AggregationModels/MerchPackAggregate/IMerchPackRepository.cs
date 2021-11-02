using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPackType>
    {
        // /// <summary>
        // /// Получить MerchPackType по идентификатору
        // /// </summary>
        // /// <param name="id">Идентификатор</param>
        // /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        // /// <returns>Объект MerchPackType</returns>
        Task<MerchPackType> GetByIdAsync(MerchType id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Enumeration.GetAll<MerchPackType>().Single(x => x.Id == (int)id));
        }
    }
}