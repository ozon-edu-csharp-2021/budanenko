using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MerchPackItemsMap
    {
        public int MerchPackTypeId { get; set; }

        public int MerchItemTypeId { get; set; }
    }
}