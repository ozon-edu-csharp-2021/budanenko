using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.MerchPackRequestAggregate
{
    public class MerchPackRequestStatusException : Exception
    {
        public MerchPackRequestStatusException(string message) : base(message)
        {
        }

        public MerchPackRequestStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}