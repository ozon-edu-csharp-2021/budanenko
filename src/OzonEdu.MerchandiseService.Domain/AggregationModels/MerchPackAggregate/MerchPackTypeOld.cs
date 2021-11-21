using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPackTypeOld : Enumeration
    {
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при устройстве на работу.
        /// </summary>
        public static MerchPackTypeOld WelcomePack = new((int)MerchTypeOld.WelcomePack, nameof(WelcomePack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.Socks});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.
        /// </summary>
        public static MerchPackTypeOld ConferenceListenerPack = new((int)MerchTypeOld.ConferenceListenerPack, nameof(ConferenceListenerPack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.TShirt});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.
        /// </summary>
        public static MerchPackTypeOld ConferenceSpeakerPack = new((int)MerchTypeOld.ConferenceSpeakerPack, nameof(ConferenceSpeakerPack),
            new[] {MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.TShirt, MerchItemType.Cap});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.
        /// </summary>
        public static MerchPackTypeOld ProbationPeriodEndingPack = new((int)MerchTypeOld.ProbationPeriodEndingPack, nameof(ProbationPeriodEndingPack),
            new[] {MerchItemType.Bag, MerchItemType.Sweatshirt, MerchItemType.Cup});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику за выслугу лет.
        /// </summary>
        public static MerchPackTypeOld VeteranPack = new((int)MerchTypeOld.VeteranPack, nameof(VeteranPack),
            new[]
            {
                MerchItemType.Bag, MerchItemType.Sweatshirt, MerchItemType.TShirt, MerchItemType.Cap, MerchItemType.Cup, 
                MerchItemType.Notepad, MerchItemType.Pen, MerchItemType.Socks
            });

        public MerchPackTypeOld(int id, string name, IReadOnlyCollection<MerchItemType> merchTypes) : base(id, name)
        {
            MerchTypes = merchTypes;
        }

        public IReadOnlyCollection<MerchItemType> MerchTypes { get; private set; }
    }
}