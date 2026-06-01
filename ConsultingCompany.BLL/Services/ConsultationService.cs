using AutoMapper;
using ConsultingCompany.BLL.Contracts.IEmailService;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.BLL.Templates;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Enums;
using ConsultingCompany.DAL.UnitOfWork;
using ConsultingCompany.Shared.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace ConsultingCompany.BLL.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ConsultationService> logger,
            IEmailService emailService,
            IStringLocalizer<SharedResource> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _localizer = localizer;
        }

       

        public async Task<int> CreateAsync(CreateConsultationRequestDto dto)
        {

            var serviceExists = await _unitOfWork
                                .GetRepository<Service>()
                                .GetByIdAsync(dto.ServiceId);

            if (serviceExists is null)
            {
                throw new ServiceNotFoundException(
                    _localizer[SharedResourcesKeys.ServiceNotFound]);
            }

            var consultation =
                _mapper.Map<ConsultationRequest>(dto);

            consultation.Status =
                ConsultationStatus.Pending;

            consultation.CreatedAt =
                DateTime.Now;

            await _unitOfWork
                .GetRepository<ConsultationRequest>()
                .AddAsync(consultation);

            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendEmailAsync(dto.Email, _localizer["ConsultationEmailSubject"],
                                EmailTemplates.ConsultationRequestConfirmation(dto.FullName, dto.CompanyName, serviceExists.Name));
    
            _logger.LogInformation("Consultation created successfully with Id: {Id}",consultation.Id);
    
            return consultation.Id;
        }
    }
}
