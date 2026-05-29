using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.Shared.Responses;

namespace ConsultingCompany.BLL.Contracts.Services
{
    public interface IConsultationService
    {
        Task<int> CreateAsync(CreateConsultationRequestDto dto);
       


    }
}
