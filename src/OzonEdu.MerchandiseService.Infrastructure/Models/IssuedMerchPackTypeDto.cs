using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public class IssuedMerchPackTypeDto
    {
        /// <summary>
        /// Тип пакета мерча, запрошенный для выдачи сотруднику
        /// </summary>
        public int MerchPackType { get; set; }
        
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime IssuedDate { get; set; }
    }
}