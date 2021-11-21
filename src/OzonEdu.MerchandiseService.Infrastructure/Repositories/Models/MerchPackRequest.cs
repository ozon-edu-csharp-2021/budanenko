using System;
using System.Diagnostics.CodeAnalysis;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class MerchPackRequest
    {
        public long MerchPackRequestId { get; set; }
        
        public int MerchPackRequestStatusId { get; set; }
        
        public int MerchPackTypeId { get; set; }
        
        public long EmployeeId { get; set; }
        
        public DateTime MerchPackRequestCreateDate { get; set; }

        public DateTime MerchPackRequestChangeDate { get; set; }
    }
}