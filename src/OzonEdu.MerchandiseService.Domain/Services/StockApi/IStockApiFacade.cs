using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Services.StockApi.StockApiModels;

namespace OzonEdu.MerchandiseService.Domain.Services.StockApi
{
    public interface IStockApiFacade
    {
        Task<List<StockItem>> GetAll();
        Task<int> GetAvailableQuantity(long stockItemSkuId);
        Task<bool> SetItemReserved(long stockItemSkuId);
    }
}