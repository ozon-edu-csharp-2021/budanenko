using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V2
{
    [ApiController]
    [Route("v2/api/merchandise")]
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
        [HttpGet]
        public async Task<IActionResult> GetMerchandiseIssuedEmployee(MerchItemGetViewModel getViewModel,
            CancellationToken token)
        {
            var merchItems = await _merchandiseService.GetMerchandiseIssuedEmployee(new MerchItemModelGet
            {
                EmployeeId = getViewModel.EmployeeId
            }, token);
            return Ok(merchItems);
        }

        /// <summary>
        /// Добавляет запрос на выдачу мерча
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchItem>> AddMerchandiseRequest(MerchItemPostViewModel postViewModel,
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