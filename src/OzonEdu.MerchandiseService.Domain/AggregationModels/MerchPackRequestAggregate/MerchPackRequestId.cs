namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class MerchPackRequestId
    {
        public MerchPackRequestId(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}