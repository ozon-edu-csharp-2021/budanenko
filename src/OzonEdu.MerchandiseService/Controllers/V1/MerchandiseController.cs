using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        /// <summary>
        /// Запросить все
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var merchItems = await _merchandiseService.GetAll(token);
            return Ok(merchItems);
        }

        /// <summary>
        /// Получить информацию о выданном мерче
        /// </summary>
        [HttpGet("employee/{employeeId:long}")]
        public async Task<IActionResult> MerchandiseIssuedEmployee(long employeeId, CancellationToken token)
        {
            var merchItems = await _merchandiseService.MerchandiseIssuedEmployee(employeeId, token);
            return Ok(merchItems);
        }

        /// <summary>
        /// Запрос на выдачу мерча
        /// </summary>
        [HttpPost("employee/{employeeId:long}/request")]
        public async Task<IActionResult> MerchandiseRequest(long employeeId, CancellationToken token)
        {
            var merchItems = await _merchandiseService.MerchandiseRequest(employeeId, token);
            return Ok(merchItems);
        }
    }
}