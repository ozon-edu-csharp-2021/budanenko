using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchPackRequest"/>
    /// </summary>
    public interface IMerchPackRequestRepository : IRepository<MerchPackRequest>
    {
        /// <summary>
        /// Получить заявку по номеру заявки
        /// </summary>
        /// <param name="requestNumber">Номер заявки</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchPackRequest> FindByRequestNumberAsync(long requestNumber,
            CancellationToken cancellationToken = default);
    }
}