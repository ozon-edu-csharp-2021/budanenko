using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.MerchPackRequestAggregate
{
    public class MerchPackRequestException : Exception
    {
        public MerchPackRequestException(string message) : base(message)
        {
        }

        public MerchPackRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}