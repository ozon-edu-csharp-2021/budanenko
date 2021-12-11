using System.Collections.Generic;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate.Responses
{
    public class GetMerchPackIssuedEmployeeQueryResponse : IIssuedMerchPackTypesModel<IssuedMerchPackTypeDto>
    {
        public IReadOnlyList<IssuedMerchPackTypeDto> MerchPackTypes { get; set; }
    }
}