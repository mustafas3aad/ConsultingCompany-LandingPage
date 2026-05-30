using Asp.Versioning;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]

    [ApiVersion("1.0")]

    [Route("api/v{version:apiVersion}/[controller]")]
    public class NewsletterSubscribersController : ControllerBase 
    {
        private readonly INewsletterSubscriberService _newsletterSubscriberService; 
        public NewsletterSubscribersController(INewsletterSubscriberService newsletterSubscriberService)    
        {
            _newsletterSubscriberService = newsletterSubscriberService;
                
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNewsletterSubscriberDto dto)   
        {
            var createdId = await _newsletterSubscriberService.CreateAsync(dto);
            return Ok(new { id = createdId });

        }
    }
}
