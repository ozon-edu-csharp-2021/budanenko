using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpClients;
using OzonEdu.MerchandiseService.HttpModels;
using Xunit;

namespace OzonEdu.MerchandiseService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task V2GetMerchandiseIssuedEmployeeTest()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            };
            var x = new MerchandiseHttpClient(client);
            var getViewModel = new GetMerchPackIssuedEmployeeModel
            {
                EmployeeId = 28
            };
            await x.V2GetMerchandiseIssuedEmployee(getViewModel, CancellationToken.None);
        }
    }
}