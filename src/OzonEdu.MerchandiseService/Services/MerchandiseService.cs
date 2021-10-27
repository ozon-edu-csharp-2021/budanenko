using System.Collections.Generic;
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
            new MerchItem(1, "Футболка", 10),
            new MerchItem(2, "Толстовка", 20),
            new MerchItem(3, "Кепка", 15)
        };

        public Task<List<MerchItem>> GetAll(CancellationToken _) => Task.FromResult(MerchItems);
        
    }
}