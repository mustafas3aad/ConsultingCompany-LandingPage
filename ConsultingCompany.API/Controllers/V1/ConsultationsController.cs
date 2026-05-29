using Asp.Versioning;
using ConsultingCompany.API.Base;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Consultations")]
    public class ConsultationsController : AppControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationsController(
            IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConsultationRequestDto dto)     
        {
            var createdId = await _consultationService.CreateAsync(dto);

            var response = new Response<int>
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Consultation request created successfully",
                Data = createdId
            };

            return NewResult(response);
        }
    }
}
