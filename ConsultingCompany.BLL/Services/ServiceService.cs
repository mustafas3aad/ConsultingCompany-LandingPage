using AutoMapper;
using ConsultingCompany.BLL.Contracts.Services;
using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.DAL.Entities;
using ConsultingCompany.DAL.Specifications.Services;
using ConsultingCompany.DAL.UnitOfWork;
using ConsultingCompany.Shared.Localization;
using ConsultingCompany.Shared.Pagination;
using ConsultingCompany.Shared.QueryParams.services;
using Microsoft.Extensions.Localization;


namespace ConsultingCompany.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
     

        public ServiceService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }

        public async Task<PaginatedResult<ServiceDto>>
            GetAllAsync(ServiceQueryParams param)
        {
            var spec =
                new ServicesWithPaginationSpecification(
                    param);

            var services = await _unitOfWork
                .GetRepository<Service>()
                .GetAllAsync(spec);

            var countSpec =
                new ServicesCountSpecification(param);

            var count = await _unitOfWork
                .GetRepository<Service>()
                .CountAsync(countSpec);

            var data =
                _mapper.Map<IEnumerable<ServiceDto>>
                (services);

            return new PaginatedResult<ServiceDto>(
                param.PageIndex,
                param.PageSize,
                count,
                data);
        }
    }
}