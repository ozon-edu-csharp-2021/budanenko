using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public long EmployeeId { get; }
        public EmployeeFullName EmployeeFullName { get; }

        public Employee(long employeeId, EmployeeFullName employeeFullName)
        {
            EmployeeId = employeeId;
            EmployeeFullName = employeeFullName;
        }
        
    // "id": 0,
    // "birthDay": "2021-10-11T19:10:32.884Z",
    // "hiringDate": "2021-10-11T19:10:32.884Z",
    // "email": "string"
    }
}