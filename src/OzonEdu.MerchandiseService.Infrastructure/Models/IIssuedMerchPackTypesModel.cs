using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public interface IIssuedMerchPackTypesModel<TIssuedMerchPackTypesModel>
        where TIssuedMerchPackTypesModel : class
    {
        IReadOnlyList<TIssuedMerchPackTypesModel> MerchPackTypes { get; set; }
    }
}