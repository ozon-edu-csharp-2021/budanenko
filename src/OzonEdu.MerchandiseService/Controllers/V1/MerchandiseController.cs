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
        /// Запросить мерч
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var merchItems = await _merchandiseService.GetAll(token);
            return Ok(merchItems);
        }
    }
}