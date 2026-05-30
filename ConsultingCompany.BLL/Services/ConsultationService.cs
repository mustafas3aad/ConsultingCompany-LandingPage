using AutoMapper;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.BLL.Exceptions;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Enums;
using ConsultingCompany.DAL.UnitOfWork;

namespace ConsultingCompany.BLL.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ConsultationService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateConsultationRequestDto dto)
        {

            var serviceExists = await _unitOfWork
                                .GetRepository<Service>()
                                .GetByIdAsync(dto.ServiceId);

            if (serviceExists is null)
                throw new ServiceNotFoundException(dto.ServiceId);

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

            return consultation.Id;
        }
    }
}
