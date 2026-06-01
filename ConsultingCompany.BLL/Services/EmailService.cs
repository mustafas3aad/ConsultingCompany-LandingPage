using ConsultingCompany.BLL.Contracts.IEmailService;
using ConsultingCompany.Shared.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConsultingCompany.BLL.Services
{
    public class EmailService(IConfiguration configuration, ILogger<EmailService> logger) : IEmailService
    {
        private readonly ILogger<EmailService> _logger = logger;

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(
                        configuration["EmailSettings:FromEmail"],
                        configuration["EmailSettings:AppPassword"]
                    ),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(configuration["EmailSettings:FromEmail"]!,SD.CompanyName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(to);
          

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError( ex,"Failed to send email to {Email}",to); 
                return false;
            }
        }
    }
}
