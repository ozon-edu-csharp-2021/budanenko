using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;
using OzonEdu.MerchandiseService.Infrastructure.Queries.EmployeeAggregate;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V3
{
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseService merchandiseService, IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавляет запрос на выдачу мерча
        /// </summary>
        [HttpPost]
        [Route("v3/api/merchandise/add")]
        public async Task<ActionResult<MerchPackRequest>> AddMerchPackRequest(
            AddMerchPackRequestModel postViewModel,
            CancellationToken token)
        {
            var addMerchPackRequestCommand = new AddMerchPackRequestCommand()
            {
                EmployeeId = postViewModel.EmployeeId,
                MerchPack = postViewModel.MerchPack
            };

            var result = await _mediator.Send(addMerchPackRequestCommand, token);

            return Ok(result);
        }

        /// <summary>
        /// Получить информацию о  мерче, выданном сотруднику
        /// </summary>
        [HttpPost]
        [Route("v3/api/merchandise/get")]
        public async Task<ActionResult<List<MerchType>>> GetMerchandiseIssuedEmployee(
            GetMerchPackIssuedEmployeeModel getMerchPackIssuedEmployeeModel,
            CancellationToken token)
        {
            var query = new GetMerchPackIssuedEmployeeQuery()
            {
                EmployeeId = getMerchPackIssuedEmployeeModel.EmployeeId
            };

            var result = await _mediator.Send(query, token);
            return Ok(result);
        }
    }
}