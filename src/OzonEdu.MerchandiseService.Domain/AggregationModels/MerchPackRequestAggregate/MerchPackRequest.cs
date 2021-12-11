using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate
{
    /// <summary>
    /// Заявка на выдачу пакета мерча
    /// </summary>
    public class MerchPackRequest : Entity
    {
        public MerchPackRequest(
            MerchPackRequestId? merchPackRequestId,
            RequestStatus requestStatus,
            MerchPackType merchPackType,
            EmployeeId employeeId,
            ClothingSize? clothingSize,
            Email email,
            CreateDate createDate,
            ChangeDate? changeDate
        )
        {
            MerchPackRequestId = merchPackRequestId;
            RequestStatus = requestStatus;
            MerchPackType = merchPackType;
            EmployeeId = employeeId;
            ClothingSize = clothingSize;
            Email = email;
            CreateDate = createDate;
            ChangeDate = changeDate;
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public MerchPackRequestId? MerchPackRequestId { get; private set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        /// <summary>
        /// Пакет мерча
        /// </summary>
        public MerchPackType MerchPackType { get; private set; }

        /// <summary>
        /// ИД сотрудника, которому предназначается мерч
        /// </summary>
        public EmployeeId EmployeeId { get; private set; }

        /// <summary>
        /// Размер одежды сотрудника
        /// </summary>
        public ClothingSize? ClothingSize { get; private set; }
        
        /// <summary>
        /// Электронный адрес сотрудника
        /// </summary>
        public Email Email { get;private set; }

        /// <summary>
        /// Дата и время создания заявки
        /// </summary>
        public CreateDate CreateDate { get; private set; }
        
        /// <summary>
        /// Дата и время изменения заявки
        /// </summary>
        public ChangeDate? ChangeDate { get; private set; }

        /// <summary>
        /// Список единиц мерча, подлежащих выдаче сотруднику в соответствии с запрошенным пакетом мерча
        /// </summary>
        public IReadOnlyCollection<MerchItem>? MerchItems { get; private set; }

        /// <summary>
        /// Причина отказа в выдаче пакета мерча
        /// </summary>
        public ReasonDenied? ReasonDenied { get; private set; }

        /// <summary>
        /// Присвоить ИД записи
        /// </summary>
        /// <param name="requestNumber"></param>
        public void SetMerchPackRequestId(long merchPackRequestId)
        {
            if (MerchPackRequestId == default)
                MerchPackRequestId = new MerchPackRequestId(merchPackRequestId);
            else
                throw new MerchPackRequestException($"MerchPackRequestId change not available!");
        }

        /// <summary>
        /// Смена статуса у заявки
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeStatus(RequestStatus status)
        {
            if (RequestStatus.Equals(RequestStatus.Done))
                throw new MerchPackRequestException($"Request in done. Change status unavailable!");

            RequestStatus = status;
        }

        public void CreateMerchItemsStatus(List<MerchItemType> merchTypes)
        {
            MerchItems = merchTypes.Select(merchItemType => new MerchItem(merchItemType)).ToList();
        }
    }
}