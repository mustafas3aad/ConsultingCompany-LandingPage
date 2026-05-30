using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/Services")]
    public class ServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Services API V2");
        }
    }
}
