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

        public EmployeeId EmployeeId => _employeeId;

        public EmployeeFullName EmployeeFullName => _employeeFullName;

        public Email Email => _email;

        public HiringDate HiringDate => _hiringDate;

        public ClothingSize ClothingSize => _clothingSize;

        public FiringDate? FiringDate => _firingDate;

        public IReadOnlyCollection<MerchType> ReceivedMerchTypes => _receivedMerchTypes;


        public bool IsPreviouslyReceived(MerchType requestMerchPack)
        {
            return ReceivedMerchTypes.Contains(requestMerchPack);
        }

        public void Add(MerchType requestMerchPack)
        {
            _receivedMerchTypes.Add(requestMerchPack);
        }
    }
}