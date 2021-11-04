using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
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
            RequestNumber? requestNumber,
            RequestStatus requestStatus,
            MerchType merchPack,
            EmployeeId employeeId)
        {
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
            MerchPack = merchPack;
            EmployeeId = employeeId;
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public RequestNumber? RequestNumber { get; private set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        /// <summary>
        /// Пакет мерча
        /// </summary>
        public MerchType MerchPack { get; private set; }

        /// <summary>
        /// ИД сотрудника, которому предназначается мерч
        /// </summary>
        public EmployeeId EmployeeId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<MerchItemStatus>? MerchItemsStatus { get; private set; }

        /// <summary>
        /// Причина отказа в выдаче пакета мерча
        /// </summary>
        public ReasonDenied? ReasonDenied { get; private set; }

        /// <summary>
        /// Присвоить номер заявки
        /// </summary>
        /// <param name="requestNumber"></param>
        public void SetRequestNumber(long requestNumber)
        {
            RequestNumber = new RequestNumber(requestNumber);
        }

        /// <summary>
        /// Смена статуса у заявки
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeStatus(RequestStatus status)
        {
            if (RequestStatus.Equals(RequestStatus.Done))
                throw new MerchPackRequestStatusException($"Request in done. Change status unavailable");

            RequestStatus = status;
        }

        public void CreateMerchItemsStatus(List<MerchItemType> merchTypes)
        {
            MerchItemsStatus = merchTypes.Select(merchItemType => new MerchItemStatus(merchItemType)).ToList();
        }
    }
}