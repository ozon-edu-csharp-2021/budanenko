using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackRequestAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.AddMerchPackRequest;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V3
{
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService, IMediator mediator)
        {
            _merchandiseService = merchandiseService;
            _mediator = mediator;
        }

        /// <summary>
        /// Добавляет запрос на выдачу мерча
        /// </summary>
        [HttpPost]
        [Route("v3/api/merchandise/add")]
        public async Task<ActionResult<MerchPackRequest>> AddMerchPackRequest(AddMerchPackRequestModel postViewModel,
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
    }
}