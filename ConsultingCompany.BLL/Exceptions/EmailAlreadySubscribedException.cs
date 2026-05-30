using ConsultingCompany.BLL.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Exceptions
{
    public class EmailAlreadySubscribedException(string email)
    : ConflictException($"Email {email} is already subscribed")
    {
    }
}
