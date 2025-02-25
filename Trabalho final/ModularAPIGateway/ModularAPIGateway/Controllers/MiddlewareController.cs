using Microsoft.AspNetCore.Mvc;

namespace ModularAPIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiddlewareController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Requisição passou pelo gateway!");
        }
    }
}

