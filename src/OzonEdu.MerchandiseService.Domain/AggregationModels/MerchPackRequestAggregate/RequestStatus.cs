using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        /// <summary>
        /// Новая
        /// </summary>
        public static RequestStatus New = new(1, "New");

        public static RequestStatus InWork = new(1, "InWork");

        /// <summary>
        /// Согласована выдача
        /// </summary>
        public static RequestStatus Agreed = new(2, "Agreed");

        /// <summary>
        /// Запрошена выдача
        /// </summary>
        public static RequestStatus Requested = new(2, "Requested");

        /// <summary>
        /// Ожидание поставки
        /// </summary>
        public static RequestStatus WaitingDelivery = new(2, "WaitingDelivery");

        /// <summary>
        /// Отказано в выдаче
        /// </summary>
        public static RequestStatus Denied = new(2, "Denied");

        /// <summary>
        /// Исполнено
        /// </summary>
        public static RequestStatus Done = new(2, "Done");

        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}