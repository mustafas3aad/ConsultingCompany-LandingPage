using AutoMapper;
using ConsultingCompany.BLL.Contracts.IEmailService;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.BLL.Templates;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Specifications.NewsletterSubscribers;
using ConsultingCompany.DAL.UnitOfWork;

namespace ConsultingCompany.BLL.Services
{
    public class NewsletterSubscriberService
        : INewsletterSubscriberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public NewsletterSubscriberService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<int> CreateAsync(CreateNewsletterSubscriberDto dto)  
        {

            var spec = new NewsletterSubscriberByEmailSpecification(dto.Email);

            var existingSubscriber = await _unitOfWork
                .GetRepository<NewsletterSubscriber>()
                .GetByIdAsync(spec);

            if (existingSubscriber is not null)
                throw new EmailAlreadySubscribedException(dto.Email);

            var subscriber =
                _mapper.Map<NewsletterSubscriber>(dto);

            subscriber.IsActive = true;

            subscriber.CreatedAt = DateTime.Now;

            await _unitOfWork
                .GetRepository<NewsletterSubscriber>()
                .AddAsync(subscriber);

            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendEmailAsync(dto.Email,"Welcome to Our Newsletter!",
                                EmailTemplates.NewsletterSubscriptionConfirmation(dto.Email));
    
            return subscriber.Id;
        }
    }
}
