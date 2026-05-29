using Asp.Versioning;
using ConsultingCompany.API.Base;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.Shared.Pagination;
using ConsultingCompany.Shared.QueryParams.services;
using ConsultingCompany.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConsultingCompany.API.Controllers.V1
{
    [ApiController]

    [ApiVersion("1.0")]

    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServicesController : AppControllerBase
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
            var result =
                await _serviceService
                    .GetAllAsync(param);

            var response =
                new Response<
                    PaginatedResult<ServiceDto>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Succeeded = true,
                    Message = "Services retrieved successfully",
                    Data = result
                };

            return NewResult(response);
        }
    }
}