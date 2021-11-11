using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPackType : Enumeration
    {
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при устройстве на работу.
        /// </summary>
        public static MerchPackType WelcomePack = new((int)MerchType.WelcomePack, nameof(WelcomePack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.Socks});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.
        /// </summary>
        public static MerchPackType ConferenceListenerPack = new((int)MerchType.ConferenceListenerPack, nameof(ConferenceListenerPack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.TShirt});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.
        /// </summary>
        public static MerchPackType ConferenceSpeakerPack = new((int)MerchType.ConferenceSpeakerPack, nameof(ConferenceSpeakerPack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.TShirt, MerchItemType.Cap});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.
        /// </summary>
        public static MerchPackType ProbationPeriodEndingPack = new((int)MerchType.ProbationPeriodEndingPack, nameof(ProbationPeriodEndingPack),
            new[] {MerchItemType.Bag, MerchItemType.Sweatshirt, MerchItemType.Cup});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику за выслугу лет.
        /// </summary>
        public static MerchPackType VeteranPack = new((int)MerchType.VeteranPack, nameof(VeteranPack),
            new[]
            {
                MerchItemType.Bag, MerchItemType.Sweatshirt, MerchItemType.TShirt, MerchItemType.Cap, MerchItemType.Cup, 
                MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.Socks
            });

        public MerchPackType(int id, string name, IReadOnlyCollection<MerchItemType> merchTypes) : base(id, name)
        {
            MerchTypes = merchTypes;
        }

        public IReadOnlyCollection<MerchItemType> MerchTypes { get; private set; }
    }
}