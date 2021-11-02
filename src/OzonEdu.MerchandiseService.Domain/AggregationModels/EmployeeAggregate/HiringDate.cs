using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class HiringDate : ValueObject
    {
        public DateTime Value { get; }
        
        public HiringDate(DateTime hiringDate)
        {
            Value = hiringDate;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}