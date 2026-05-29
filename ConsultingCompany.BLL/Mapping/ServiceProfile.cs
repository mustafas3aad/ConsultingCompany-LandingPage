using AutoMapper;
using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.DAL.Entities;

namespace ConsultingCompany.BLL.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>();
        }
    }
}