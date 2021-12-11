using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchPackRequestAggregate;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchandiseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавляет запрос на выдачу мерча сотруднику
        /// </summary>
        [HttpPost]
        [Route("v1/api/merchandise/add")]
        public async Task<ActionResult<long>> AddMerchPackRequest(
            AddMerchPackRequestPostViewModel postViewModel,
            CancellationToken token)
        {
            var addMerchPackRequestCommand = new AddMerchPackRequestCommand()
            {
                MerchPackType = postViewModel.MerchPackType,
                EmployeeId = postViewModel.EmployeeId,
                ClothingSize = postViewModel.ClothingSize,
                Email = postViewModel.Email
            };

            var result = await _mediator.Send(addMerchPackRequestCommand, token);

            return Ok(result);
        }

        /// <summary>
        /// Получить информацию о мерче, выданном сотруднику
        /// </summary>
        [HttpPost]
        [Route("v1/api/merchandise/get")]
        public async Task<ActionResult<List<MerchTypeOld>>> GetMerchandiseIssuedEmployee(
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