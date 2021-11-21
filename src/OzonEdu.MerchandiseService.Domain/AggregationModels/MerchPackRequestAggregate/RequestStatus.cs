using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        /// <summary>
        /// Новая
        /// </summary>
        public static RequestStatus New = new(1, "New");

        /// <summary>
        /// В работе
        /// </summary>
        public static RequestStatus InWork = new(2, "InWork");

        /// <summary>
        /// Согласована выдача
        /// </summary>
        public static RequestStatus Agreed = new(3, "Agreed");

        /// <summary>
        /// Запрошена выдача
        /// </summary>
        public static RequestStatus Requested = new(4, "Requested");

        /// <summary>
        /// Ожидание поставки
        /// </summary>
        public static RequestStatus WaitingDelivery = new(5, "WaitingDelivery");

        /// <summary>
        /// Отказано в выдаче
        /// </summary>
        public static RequestStatus Denied = new(6, "Denied");

        /// <summary>
        /// Исполнено
        /// </summary>
        public static RequestStatus Done = new(7, "Done");

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}