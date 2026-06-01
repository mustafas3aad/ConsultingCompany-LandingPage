using System.ComponentModel.DataAnnotations;

namespace ConsultingCompany.BLL.DTOs.ConsultationRequests
{
    public class CreateConsultationRequestDto
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string CompanyName { get; set; } = default!;

       
        public string Message { get; set; } = default!;

        [Required]
        public int ServiceId { get; set; }
    }
}
