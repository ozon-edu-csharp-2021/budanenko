using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        public static RequestStatus InWork = new(1, "InWork");
        public static RequestStatus Done = new(1, "Done");
        
        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}