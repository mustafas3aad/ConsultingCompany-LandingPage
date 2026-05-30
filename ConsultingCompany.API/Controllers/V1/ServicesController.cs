using Asp.Versioning;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.Shared.QueryParams.services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]

    [ApiVersion("1.0")]

    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(
            IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] ServiceQueryParams param)
        {
            var result = await _serviceService.GetAllAsync(param);      
            return Ok(result);

        }
    }
}