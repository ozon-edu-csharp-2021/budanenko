using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var resultObject = new
            {
                version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
                serviceName = Assembly.GetExecutingAssembly().GetName().Name
            };

            var jsonResult = new JsonResult(resultObject)
            {
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = StatusCodes.Status200OK 
            };
            await context.Response.WriteAsJsonAsync(jsonResult);
        }
    }
}