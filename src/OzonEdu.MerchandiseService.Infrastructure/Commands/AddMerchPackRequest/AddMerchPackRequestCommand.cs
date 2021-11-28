using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest
{
    public class AddMerchPackRequestCommand : IRequest<long>
    {
        /// <summary>
        /// Тип пакета мерча, запрошенный для выдачи сотруднику
        /// </summary>
        public int MerchPackType { get; set; }
        
        /// <summary>
        /// Ид сотрудника
        /// </summary>
        public long EmployeeId { get; set; }
        
        /// <summary>
        /// Размер одежды сотрудника
        /// </summary>
        public int ClothingSize { get; set; }
        
        /// <summary>
        /// Электронный адрес сотрудника
        /// </summary>
        public string Email { get; set; }
    }
}