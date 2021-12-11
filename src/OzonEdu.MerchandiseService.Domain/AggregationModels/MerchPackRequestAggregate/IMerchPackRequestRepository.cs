using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchPackRequest"/>
    /// </summary>
    public interface IMerchPackRequestRepository : IRepository<MerchPackRequest>
    {
        Task<MerchPackRequest> CreateAsync(MerchPackRequest recordToCreate, CancellationToken cancellationToken);

        Task<MerchPackRequest> UpdateStatusAsync(MerchPackRequest recordToUpdate, CancellationToken cancellationToken);
 /*       
        /// <summary>
        /// Получить заявку по номеру заявки
        /// </summary>
        /// <param name="merchPackRequestId">Номер заявки</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект заявки</returns>
        Task<MerchPackRequest?> FindByRequestNumberAsync(MerchPackRequestId merchPackRequestId,
            CancellationToken cancellationToken = default);
*/
        /// <summary>
        /// Получить список заявок в статусе "Новая" или "В работе" для набора пакетов с мерчем
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Список заявок на выдачу мерча</returns>
        Task<IReadOnlyCollection<MerchPackRequest>> GetMerchPackRequestForAssembly(CancellationToken cancellationToken = default);
 
        /// <summary>
        /// Получить список заявок для набора пакетов с мерчем по сотруднику
        /// </summary>
        /// <param name="employeeId">ИД сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Список заявок на выдачу мерча</returns>
        Task<IReadOnlyCollection<MerchPackRequest>> GetMerchPackRequestsByEmployeeIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default);
    }
}