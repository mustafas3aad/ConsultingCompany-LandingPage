using Asp.Versioning;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/NewsletterSubscribers")]
    public class NewsletterSubscribersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("NewsletterSubscribers API V2");
        }
    }
}
