using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
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
            RequestNumber requestNumber,
            RequestStatus requestStatus,
            MerchPackType merchPack,
            EmployeeId employeeId
        )
        {
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
            MerchPack = merchPack;
            EmployeeId = employeeId;
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public RequestNumber RequestNumber { get; private set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        /// <summary>
        /// Пакет мерча
        /// </summary>
        public MerchPackType MerchPack { get; private set; }

        /// <summary>
        /// ИД сотрудника, которому предназначается мерч
        /// </summary>
        public EmployeeId EmployeeId { get; private set; }

        public void SetRequestNumber(RequestNumber number)
        {
            RequestNumber = number;
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
    }
}