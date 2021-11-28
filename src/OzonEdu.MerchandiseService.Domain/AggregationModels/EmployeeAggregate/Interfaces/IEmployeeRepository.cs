using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="Employee"/>
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Получить сведения о сотруднике по идентификатору
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Объект сотрудника</returns>
        Task<Employee?> FindByIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить список пакетов мерча, выданных сотруднику
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции</param>
        /// <returns>Коллекция типов мерча</returns>
        Task<List<MerchTypeOld>> GetEmployeeMerchTypes(EmployeeId employeeId,
            CancellationToken cancellationToken = default);
    }
}