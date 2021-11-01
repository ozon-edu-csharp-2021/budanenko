using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchPackRequest"/>
    /// </summary>
    public interface IMerckPackRequestRepository : IRepository<MerchPackRequest>
    {
        /// <summary>
        /// Получить заявку по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchPackRequest> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить заявку по номеру заявки
        /// </summary>
        /// <param name="stockItem">Номер заявки</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchPackRequest> FindByRequestNumberAsync(RequestNumber requestNumber,
            CancellationToken cancellationToken = default);
    }
}