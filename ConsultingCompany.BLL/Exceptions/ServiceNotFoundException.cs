using ConsultingCompany.BLL.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Exceptions
{
    public class ServiceNotFoundException(int id)
    : NotFoundException($"Service with id {id} is not found")
    {
    }
}
