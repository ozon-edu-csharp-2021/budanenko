using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class ReasonDenied : ValueObject
    {
        public string Value { get; }

        public ReasonDenied(string reasonDenied)
        {
            Value = reasonDenied;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}