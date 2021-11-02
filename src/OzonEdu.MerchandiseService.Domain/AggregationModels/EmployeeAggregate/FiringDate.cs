using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class FiringDate : ValueObject
    {
        public DateTime Value { get; }  
        
        public FiringDate(DateTime firingDate)
        {
            Value = firingDate;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}