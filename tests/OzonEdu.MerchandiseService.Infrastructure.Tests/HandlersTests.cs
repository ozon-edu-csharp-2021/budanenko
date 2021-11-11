using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using OzonEdu.MerchandiseService.Domain.AggregationModels;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate.Interfaces;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;
using OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchPackRequestAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Infrastructure.Tests
{
    public class HandlersTests
    {
        [Fact]
        public async Task AddMerchPackRequestCommandHandlerTests()
        {
            MerchPackRequest? merchPackRequest = null;
            // Arrange
            var mock1 = new Mock<IEmployeeRepository>();
            mock1.Setup(a => a.FindByIdAsync(It.IsAny<EmployeeId>(), It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(new Employee(
                    new EmployeeId(1),
                    new EmployeeFullName("Иванов", "Иван", "Иванович"),
                    new Email("mail@mail.com"),
                    new HiringDate(DateTime.Now),
                    ClothingSize.XS,
                    null,
                    null))
                );

            var mock2 = new Mock<IMerchPackRequestRepository>();
            mock2.Setup(a => a.CreateAsync(It.IsAny<MerchPackRequest>(), It.IsAny<CancellationToken>()))
                .Callback<MerchPackRequest, CancellationToken>((x, y) => { merchPackRequest = x; });

            var mock3 = new Mock<IUnitOfWork>();
            mock3.Setup(a => a.SaveEntitiesAsync(It.IsAny<CancellationToken>()));

            mock2.Setup(a => a.UnitOfWork).Returns(mock3.Object);

            AddMerchPackRequestCommandHandler controller =
                new AddMerchPackRequestCommandHandler(mock1.Object, mock2.Object);

            // Act
            var a = await controller.Handle(
                new AddMerchPackRequestCommand() {EmployeeId = 1, MerchPack = MerchType.WelcomePack},
                CancellationToken.None);

            // Assert
            Assert.NotNull(merchPackRequest);
        }
    }
}