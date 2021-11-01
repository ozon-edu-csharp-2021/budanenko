using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Models
{
    public class MerchItemModelCreate
    {
        public MerchPackType MerchPack { get; set; }
        public long EmployeeId { get; set; }
    }
}