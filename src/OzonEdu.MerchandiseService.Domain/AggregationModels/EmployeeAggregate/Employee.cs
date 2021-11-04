using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        private readonly EmployeeId _employeeId;
        private readonly EmployeeFullName _employeeFullName;
        private readonly Email _email;
        private readonly HiringDate _hiringDate;
        private readonly ClothingSize _clothingSize;
        private readonly FiringDate? _firingDate;
        private readonly List<MerchType> _receivedMerchTypes;

        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee(
            EmployeeId employeeId,
            EmployeeFullName employeeFullName,
            Email email,
            HiringDate hiringDate,
            ClothingSize clothingSize,
            FiringDate? firingDate,
            IReadOnlyCollection<MerchType>? receivedMerchTypes)
        {
            _employeeId = employeeId;
            _employeeFullName = employeeFullName;
            _email = email;
            _hiringDate = hiringDate;
            _clothingSize = clothingSize;
            _firingDate = firingDate;
            _receivedMerchTypes = receivedMerchTypes?.ToList() ?? new List<MerchType>();
        }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public EmployeeId EmployeeId => _employeeId;

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public EmployeeFullName EmployeeFullName => _employeeFullName;

        /// <summary>
        /// Электронный адрес сотрудника
        /// </summary>
        public Email Email => _email;

        /// <summary>
        /// Дата устройства на работу
        /// </summary>
        public HiringDate HiringDate => _hiringDate;

        /// <summary>
        /// Размер одежды сотрудника
        /// </summary>
        public ClothingSize ClothingSize => _clothingSize;

        /// <summary>
        /// Дата увольнения
        /// </summary>
        public FiringDate? FiringDate => _firingDate;

        /// <summary>
        /// Список ранее выданных наборов мерча
        /// </summary>
        public IReadOnlyCollection<MerchType> ReceivedMerchTypes => _receivedMerchTypes;

        /// <summary>
        /// Проверка выдавался ли ранее данный набор сотруднику
        /// </summary>
        /// <param name="requestMerchPack">Набор мерча</param>
        /// <returns>Результат: выдавался или нет</returns>
        public bool IsPreviouslyReceived(MerchType requestMerchPack)
        {
            return ReceivedMerchTypes.Contains(requestMerchPack);
        }

        /// <summary>
        /// Добавить в список раннее выданных пакетов новый набор
        /// </summary>
        /// <param name="requestMerchPack">Набор мерча</param>
        public void AddReceivedMerchType(MerchType requestMerchPack)
        {
            _receivedMerchTypes.Add(requestMerchPack);
        }
    }
}