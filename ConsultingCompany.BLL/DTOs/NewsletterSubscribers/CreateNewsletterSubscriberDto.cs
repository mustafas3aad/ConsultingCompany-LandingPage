using System.ComponentModel.DataAnnotations;

namespace ConsultingCompany.BLL.DTOs.NewsletterSubscribers
{
    public class CreateNewsletterSubscriberDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; } = default!;
    }
}
