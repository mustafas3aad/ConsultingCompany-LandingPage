using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.BLL.Contracts.IEmailService
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string body);

    }
}
