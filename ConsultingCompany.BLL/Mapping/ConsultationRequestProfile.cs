using AutoMapper;
using ConsultingCompany.BLL.DTOs.ConsultationRequests;
using ConsultingCompany.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Mapping
{
    public class ConsultationRequestProfile: Profile
    {
        public ConsultationRequestProfile()
        {
            CreateMap<CreateConsultationRequestDto,ConsultationRequest>();
                
        }
    }
}
