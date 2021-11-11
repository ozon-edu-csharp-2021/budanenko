using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Services.StockApi.StockApiModels;

namespace OzonEdu.MerchandiseService.Domain.Services.StockApi
{
    public class StockApiFacade : IStockApiFacade
    {
        public Task<List<StockItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetAvailableQuantity(long stockItemSkuId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SetItemReserved(long stockItemSkuId)
        {
            throw new System.NotImplementedException();
        }
    }
}