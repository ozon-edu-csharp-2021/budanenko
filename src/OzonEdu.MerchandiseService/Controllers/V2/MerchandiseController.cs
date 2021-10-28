using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V2
{
    [ApiController]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        /// <summary>
        /// Получить информацию о выданном мерче
        /// </summary>
        [HttpPost]
        [Route("v2/api/merchandise/get")]
        public async Task<IActionResult> GetMerchandiseIssuedEmployee(GetMerchandiseIssuedEmployeeModel getMerchandiseIssuedEmployeeModel,
            CancellationToken token)
        {
            throw new Exception("Error");
            var merchItems = await _merchandiseService.GetMerchandiseIssuedEmployee(new MerchItemModelGet
            {
                EmployeeId = getMerchandiseIssuedEmployeeModel.EmployeeId
            }, token);
            return Ok(merchItems);
        }

        /// <summary>
        /// Добавляет запрос на выдачу мерча
        /// </summary>
        [HttpPost]
        [Route("v2/api/merchandise/add")]
        public async Task<ActionResult<MerchItem>> AddMerchandiseRequest(AddMerchandiseRequestModel postViewModel,
            CancellationToken token)
        {
            var createdMerchItem = await _merchandiseService.AddMerchandiseRequest(new MerchItemModelCreate
            {
                EmployeeId = postViewModel.EmployeeId
            }, token);
            return Ok(createdMerchItem);
        }
    }
}