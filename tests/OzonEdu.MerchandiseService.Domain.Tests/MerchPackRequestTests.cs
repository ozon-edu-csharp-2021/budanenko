using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchPackRequestAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchPackRequestTests
    {
        [Fact]
        public void SetRequestNumberSuccess()
        {
            //Arrange 
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.New,
                MerchType.WelcomePack,
                new EmployeeId(10)
            );

            //Act
            merchPackRequest.SetRequestNumber(100);

            //Assert
            Assert.Equal((long)100,merchPackRequest.RequestNumber!.Value);
        }

        [Fact]
        public void ChangeStatusFailed()
        {
            //Arrange 
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.Done,
                MerchType.WelcomePack,
                new EmployeeId(10)
            );
            var requestStatus = RequestStatus.Done;

            //Act

            //Assert
            Assert.Throws<MerchPackRequestStatusException>(() => merchPackRequest.ChangeStatus(requestStatus));
        }

        [Fact]
        public void CreateMerchItemsStatusSuccess()
        {
            //Arrange 
            var merchPackRequest = new MerchPackRequest(
                null,
                RequestStatus.Done,
                MerchType.WelcomePack,
                new EmployeeId(10)
            );
            var merchPackType = new MerchPackType((int)MerchType.WelcomePack, "WelcomePackTest",
                new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.Socks});

            //Act
            merchPackRequest.CreateMerchItemsStatus(merchPackType.MerchTypes.ToList());
            
            //Assert
            Assert.Equal(Status.New,merchPackRequest.MerchItemsStatus.FirstOrDefault().Status); 
        }
    }
}