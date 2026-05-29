using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;

namespace ConsultingCompany.BLL.Contracts.Services
{
    public interface INewsletterSubscriberService
    {
        Task<int> CreateAsync(CreateNewsletterSubscriberDto dto);
            
    }
}
