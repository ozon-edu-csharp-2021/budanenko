namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class EmployeeId
    {
        public EmployeeId(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}