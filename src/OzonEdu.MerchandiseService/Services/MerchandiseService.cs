using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly List<MerchItem> MerchItems = new List<MerchItem>
        {
            new MerchItem(1,248,28,3),
            new MerchItem(2,234,23,2),
            new MerchItem(3,248,44,1),
            new MerchItem(4,121,28,9),
            new MerchItem(5,234,44,4),
            new MerchItem(6,121,7,1),
        };

        public Task<List<MerchItem>> GetAll(CancellationToken _) => Task.FromResult(MerchItems);
        
        public Task<List<MerchItem>> MerchandiseIssuedEmployee(long employeeId, CancellationToken _) => 
            Task.FromResult(MerchItems.FindAll(x => x.EmployeeId == employeeId));
        
        public Task<MerchItem> MerchandiseRequest(long employeeId, CancellationToken _)
        {
            var newItemId = MerchItems.Max(x => x.MerchItemId) + 1;
            var newMerchItem = new MerchItem(newItemId, null, employeeId, null);
            MerchItems.Add(newMerchItem);
            return Task.FromResult(newMerchItem);
        }
        
        public Task<MerchItem> AddMerchandise(MerchItemModelCreate merchItem, CancellationToken _)
        {
            var newItemId = MerchItems.Max(x => x.MerchItemId) + 1;
            var newMerchItem = new MerchItem(newItemId, null, merchItem.EmployeeId, null);
            MerchItems.Add(newMerchItem);
            return Task.FromResult(newMerchItem);
        }
        
        public Task<List<MerchItem>> GetMerchandiseIssuedEmployee(MerchItemModelGet merchItem, CancellationToken token)=> 
            Task.FromResult(MerchItems.FindAll(x => x.EmployeeId == merchItem.EmployeeId));
    }
}