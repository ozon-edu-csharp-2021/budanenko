using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchItemType : Enumeration
    {
        public static MerchItemType TShirtStarter = new(1, nameof(TShirtStarter));
        public static MerchItemType NotepadStarter = new(2, nameof(NotepadStarter));
        public static MerchItemType PenStarter = new(3, nameof(PenStarter));
        public static MerchItemType SocksStarter = new(4, nameof(SocksStarter));
        public static MerchItemType TShirtAfterProbation = new(5, nameof(TShirtAfterProbation));
        public static MerchItemType SweatshirtAfterProbation = new(6, nameof(SweatshirtAfterProbation));
        public static MerchItemType SweatshirtСonferenceSpeaker = new(7, nameof(SweatshirtСonferenceSpeaker));
        public static MerchItemType NotepadСonferenceSpeaker = new(8, nameof(NotepadСonferenceSpeaker));
        public static MerchItemType PenСonferenceSpeaker = new(9, nameof(PenСonferenceSpeaker));
        public static MerchItemType TShirtСonferenceListener = new(10, nameof(TShirtСonferenceListener));
        public static MerchItemType NotepadСonferenceListener = new(11, nameof(NotepadСonferenceListener));
        public static MerchItemType PenСonferenceListener = new(12, nameof(PenСonferenceListener));
        public static MerchItemType TShirtVeteran = new(13, nameof(TShirtVeteran));
        public static MerchItemType SweatshirtVeteran = new(14, nameof(SweatshirtVeteran));
        public static MerchItemType NotepadVeteran = new(15, nameof(NotepadVeteran));
        public static MerchItemType PenVeteran = new(16, nameof(PenVeteran));
        public static MerchItemType CardHolderVeteran = new(17, nameof(CardHolderVeteran));


        public MerchItemType(int id, string name) : base(id, name)
        {
        }
    }
}