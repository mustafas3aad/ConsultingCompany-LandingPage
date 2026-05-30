using AutoMapper;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.NewsletterSubscribers;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.BLL.Exceptions.Base;
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

        public NewsletterSubscriberService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return subscriber.Id;
        }
    }
}
