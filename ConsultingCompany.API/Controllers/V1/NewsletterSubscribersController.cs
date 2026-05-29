using Asp.Versioning;
using ConsultingCompany.API.Base;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using ConsultingCompany.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]

    [ApiVersion("1.0")]

    [Route("api/v{version:apiVersion}/[controller]")]
    public class NewsletterSubscribersController : AppControllerBase  
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
            
            var response = new Response<int>
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Subscribed successfully",
                Data = createdId
            };

            return NewResult(response);
        }
    }
}
