using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels
{
    public class MerchType : Enumeration
    {
        /// <summary>
        /// Футболка
        /// </summary>
        public static MerchType TShirt = new(1, nameof(TShirt));
        
        /// <summary>
        /// Свитер
        /// </summary>
        public static MerchType Sweatshirt = new(2, nameof(Sweatshirt));
        
        /// <summary>
        /// Блокнот
        /// </summary>
        public static MerchType Notepad = new(3, nameof(Notepad));
        
        /// <summary>
        /// Сумка
        /// </summary>
        public static MerchType Bag = new(4, nameof(Bag));
        
        /// <summary>
        /// Ручка
        /// </summary>
        public static MerchType Pen = new(5, nameof(Pen));
        
        /// <summary>
        /// Носки
        /// </summary>
        public static MerchType Socks = new(6, nameof(Socks));
        
        /// <summary>
        /// Кепка
        /// </summary>
        public static MerchType Cap = new(7, nameof(Cap));
        
        /// <summary>
        /// Чашка
        /// </summary>
        public static MerchType Cup = new(8, nameof(Cup));

        public MerchType(int id, string name) : base(id, name)
        {
        }
    }
}