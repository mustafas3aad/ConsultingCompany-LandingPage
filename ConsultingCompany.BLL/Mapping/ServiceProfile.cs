using AutoMapper;
using ConsultingCompany.BLL.DTOs.Services;
using ConsultingCompany.DAL.Entities;
using System.Globalization;

namespace ConsultingCompany.BLL.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>()
                    .ForMember(dest => dest.Name,
                        opt => opt.MapFrom(src =>
                            CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar"
                                ? src.NameAr
                                : src.Name
                        )
                    );
        }
    }
}