using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> Employees = new List<Employee>
        {
            new Employee(new EmployeeId(7), new EmployeeFullName("Пушкин", "Александр", "Сергеевич"),
                new Email("a.s.pushkin@ozon.ru"), new HiringDate(DateTime.Parse("2009-06-06")), ClothingSize.L, null,
                    new List<MerchTypeOld> { MerchTypeOld.ConferenceSpeakerPack, MerchTypeOld.VeteranPack }),
                new Employee(new EmployeeId(17), new EmployeeFullName("Лермонтов", "Михаил", "Юрьевич"),
                    new Email("m.yu.lermontov@ozon.ru"), new HiringDate(DateTime.Parse("2014-10-15")), ClothingSize.L, null,
                    new List<MerchTypeOld> { MerchTypeOld.ConferenceSpeakerPack, MerchTypeOld.ConferenceListenerPack }),
                new Employee(new EmployeeId(28), new EmployeeFullName("Толстой", "Лев", "Николаевич"),
                    new Email("l.n.tolstoy@ozon.ru"), new HiringDate(DateTime.Parse("2018-08-28")), ClothingSize.XXL, null,
                    new List<MerchTypeOld> { MerchTypeOld.WelcomePack, MerchTypeOld.ProbationPeriodEndingPack }),
                new Employee(new EmployeeId(83), new EmployeeFullName("Достоевский", "Фёдор", "Михайлович"),
                    new Email("f.m.dostoevskiy@ozon.ru"), new HiringDate(DateTime.Parse("2021-11-11")), ClothingSize.XL, null,
                    new List<MerchTypeOld> { MerchTypeOld.WelcomePack }), 
        };

        public IUnitOfWork UnitOfWork { get; }

        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee?> FindByIdAsync(EmployeeId employeeId, CancellationToken cancellationToken = default)
        {
            var result = Task.FromResult(Employees.Find(x => x.EmployeeId.Value == employeeId.Value));
            if (result is null)
                throw new ArgumentNullException($"{nameof(result)} value is null");
            
            return result;
        }

        public Task<List<MerchTypeOld>> GetEmployeeMerchTypes(EmployeeId employeeId,
            CancellationToken cancellationToken = default)
        {
            Employee? employee = Employees.Find(x => x.EmployeeId.Value == employeeId.Value);
            if (employee is null)
                throw new ArgumentNullException($"{nameof(employee)} value is null");
            
            return Task.FromResult(employee.ReceivedMerchTypes.ToList());
        }
    }
}