namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
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