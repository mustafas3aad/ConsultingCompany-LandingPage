using Asp.Versioning;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Consultations")]
    public class ConsultationsController : ControllerBase
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
            return Ok(new { id = createdId });

        }
    }
}
