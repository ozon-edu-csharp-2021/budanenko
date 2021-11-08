using System;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void AddReceivedMerchTypeSuccess()
        {
            //Arrange 
            var employee = new Employee(
                new EmployeeId(10), 
                new EmployeeFullName("Чехов", "Антон", "Павлович"),
                new Email("a.p.chekhov@ozon.ru"), 
                new HiringDate(DateTime.Parse("2020-01-29")), 
                ClothingSize.M, 
                null,
                null
                );
            var requestMerchPack = MerchType.WelcomePack;
        
            //Act
            employee.AddReceivedMerchType(requestMerchPack);

            //Assert
            Assert.True(employee.ReceivedMerchTypes.First() == MerchType.WelcomePack);
        }
        
        [Fact]
        public void IsPreviouslyReceivedSuccess()
        {
            //Arrange 
            var employee = new Employee(
                new EmployeeId(10), 
                new EmployeeFullName("Чехов", "Антон", "Павлович"),
                new Email("a.p.chekhov@ozon.ru"), 
                new HiringDate(DateTime.Parse("2020-01-29")), 
                ClothingSize.M, 
                null,
                null
            );
            var requestMerchPack = MerchType.WelcomePack;
        
            //Act
            var result = employee.IsPreviouslyReceived(requestMerchPack);

            //Assert
            Assert.False(result);
        }
    }
}