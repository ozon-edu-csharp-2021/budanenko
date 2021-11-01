using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels
{
    public class MerchPackType : Enumeration
    {
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при устройстве на работу.
        /// </summary>
        public static MerchPackType WelcomePack = new(10, nameof(WelcomePack),
            new[] {MerchType.Notepad, MerchType.Pen, MerchType.Socks});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.
        /// </summary>
        public static MerchPackType ConferenceListenerPack = new(20, nameof(ConferenceListenerPack),
            new[] {MerchType.Notepad, MerchType.Pen, MerchType.TShirt});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.
        /// </summary>
        public static MerchPackType ConferenceSpeakerPack = new(30, nameof(ConferenceSpeakerPack),
            new[] {MerchType.Notepad, MerchType.Pen, MerchType.TShirt, MerchType.Cap});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.
        /// </summary>
        public static MerchPackType ProbationPeriodEndingPack = new(40, nameof(ProbationPeriodEndingPack),
            new[] {MerchType.Bag, MerchType.Sweatshirt, MerchType.Cup});

        /// <summary>
        /// Набор мерча, выдаваемый сотруднику за выслугу лет.
        /// </summary>
        public static MerchPackType VeteranPack = new(50, nameof(VeteranPack),
            new[]
            {
                MerchType.Bag, MerchType.Sweatshirt, MerchType.TShirt, MerchType.Cap, MerchType.Cup, 
                MerchType.Notepad, MerchType.Pen, MerchType.Socks
            });

        public MerchPackType(int id, string name, IReadOnlyCollection<MerchType> merchTypes) : base(id, name)
        {
            MerchTypes = merchTypes;
        }

        public IReadOnlyCollection<MerchType> MerchTypes { get; private set; }
    }
}