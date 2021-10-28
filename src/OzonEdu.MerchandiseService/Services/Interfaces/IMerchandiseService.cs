using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<List<MerchItem>> GetAll(CancellationToken token);
        
        Task<List<MerchItem>> MerchandiseIssuedEmployee(long employeeId, CancellationToken token);
        
        Task<MerchItem> MerchandiseRequest(long employeeId, CancellationToken token);
        
        Task<MerchItem> AddMerchandiseRequest(MerchItemModelCreate merchItem, CancellationToken token);
        
        Task<List<MerchItem>> GetMerchandiseIssuedEmployee(MerchItemModelGet merchItem, CancellationToken token);
    }
}