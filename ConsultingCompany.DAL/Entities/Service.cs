using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultingCompany.DAL.Entities
{
    [Table("Services")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = default!;

        [Required]
        public bool IsActive { get; set; } = true;

        public ICollection<ConsultationRequest> ConsultationRequests { get; set; } = new List<ConsultationRequest>();
    }
}