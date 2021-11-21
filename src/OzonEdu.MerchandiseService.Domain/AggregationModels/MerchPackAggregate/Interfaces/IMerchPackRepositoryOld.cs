using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces
{
    public interface IMerchPackRepositoryOld : IRepository<MerchPackTypeOld>
    {
        // /// <summary>
        // /// Получить MerchPackType по идентификатору
        // /// </summary>
        // /// <param name="id">Идентификатор</param>
        // /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        // /// <returns>Объект MerchPackType</returns>
        Task<MerchPackTypeOld> GetByIdAsync(MerchTypeOld id, CancellationToken cancellationToken = default);
    }
}