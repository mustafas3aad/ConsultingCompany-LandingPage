using ConsultingCompany.BLL.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Exceptions
{
    public class ServiceNotFoundException(string message)
    : NotFoundException(message)
    {
    }
}
