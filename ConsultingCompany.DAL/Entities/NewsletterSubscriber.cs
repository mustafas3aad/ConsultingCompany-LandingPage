using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultingCompany.DAL.Entities
{
    [Table("NewsletterSubscribers")]
    public class NewsletterSubscriber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public bool IsActive { get; set; } = false;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}