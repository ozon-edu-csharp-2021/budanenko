using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItemType : Enumeration
    {
        /// <summary>
        /// Футболка
        /// </summary>
        public static MerchItemType TShirt = new(1, nameof(TShirt));
        
        /// <summary>
        /// Свитер
        /// </summary>
        public static MerchItemType Sweatshirt = new(2, nameof(Sweatshirt));
        
        /// <summary>
        /// Блокнот
        /// </summary>
        public static MerchItemType Notepad = new(3, nameof(Notepad));
        
        /// <summary>
        /// Сумка
        /// </summary>
        public static MerchItemType Bag = new(4, nameof(Bag));
        
        /// <summary>
        /// Ручка
        /// </summary>
        public static MerchItemType Pen = new(5, nameof(Pen));
        
        /// <summary>
        /// Носки
        /// </summary>
        public static MerchItemType Socks = new(6, nameof(Socks));
        
        /// <summary>
        /// Кепка
        /// </summary>
        public static MerchItemType Cap = new(7, nameof(Cap));
        
        /// <summary>
        /// Чашка
        /// </summary>
        public static MerchItemType Cup = new(8, nameof(Cup));

        public MerchItemType(int id, string name) : base(id, name)
        {
        }
    }
}