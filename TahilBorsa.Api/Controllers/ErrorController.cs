using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /*Projede yasanacak bir hatada kullanıcı  buradaki mesajı görecek*/

        [Route("/Error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            return Problem();
        }

        /*Projede yasanacak bir hatada development ise  buradaki mesajı görecek*/

        [Route("Error/-development")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(detail: exceptionHandlerFeature.Error.StackTrace, title: exceptionHandlerFeature.Error.Message);

        }
    }
}
