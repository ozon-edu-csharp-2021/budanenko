using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.HttpModels
{
    public class AddMerchPackRequestModel
    {
        public MerchTypeOld MerchPack { get; set; }
        public long EmployeeId { get; set; }
    }
}