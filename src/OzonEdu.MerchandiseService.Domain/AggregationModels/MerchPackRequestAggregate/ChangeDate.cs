using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class ChangeDate : ValueObject
    {
        public DateTime Value { get; }  
        
        public ChangeDate(DateTime changeDate)
        {
            Value = changeDate;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}