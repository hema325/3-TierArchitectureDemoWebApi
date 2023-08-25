using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PresentationLayer.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult Result<TData>(Result<TData> result) => result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            _ => StatusCode((int)result.StatusCode, result)
        };
        
    }
}
