using ConsultingCompany.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultingCompany.DAL.Entities
{
    [Table("ConsultationRequests")]
    public class ConsultationRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("FullName")]
        public string FullName { get; set; } = default!;

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; } = default!;

        
        [MaxLength(2000)]
        public string? Message { get; set; } = default!;

        [Required]
        public ConsultationStatus Status { get; set; }

        [Required]
        public bool IsRead { get; set; } = false;

        [Required]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        public Service? Service { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}