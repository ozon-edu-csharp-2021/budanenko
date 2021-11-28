using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class MerchPackType : Enumeration
    {
        public static MerchPackType Starter = new(1, nameof(Starter));
        public static MerchPackType AfterProbation = new(2, nameof(AfterProbation));
        public static MerchPackType СonferenceSpeaker = new(3, nameof(СonferenceSpeaker));
        public static MerchPackType СonferenceListener = new(4, nameof(СonferenceListener));
        public static MerchPackType Veteran = new(5, nameof(Veteran));

        public MerchPackType(int id, string name) : base(id, name)
        {
        }
    }
}