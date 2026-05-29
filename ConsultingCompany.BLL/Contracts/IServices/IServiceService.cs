using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.Shared.Pagination;
using ConsultingCompany.Shared.QueryParams.services;

namespace ConsultingCompany.BLL.Contracts.Services
{
    public interface IServiceService
    {
        Task<PaginatedResult<ServiceDto>> GetAllAsync(ServiceQueryParams param);
            
    }
}
