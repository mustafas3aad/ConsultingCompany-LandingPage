using AutoMapper;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using ConsultingCompany.DAL.Entities;

namespace ConsultingCompany.BLL.Mapping
{
    public class NewsletterSubscriberProfile : Profile
    {
        public NewsletterSubscriberProfile()
        {
            CreateMap<CreateNewsletterSubscriberDto,NewsletterSubscriber>();
                
        }
    }
}
