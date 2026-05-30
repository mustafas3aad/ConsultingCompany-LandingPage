using ConsultingCompany.BLL.DTOs.ConsultationRequests;

namespace ConsultingCompany.BLL.Contracts.Services
{
    public interface IConsultationService
    {
        Task<int> CreateAsync(CreateConsultationRequestDto dto);
       


    }
}
