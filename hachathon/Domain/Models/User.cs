using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hachathon.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public Phone Phone { get; set; }
        [Required]
        public int PhoneId { get; set; }
        public Plan Plan { get; set; }
        [Required]
        public int PlanId { get; set; } 
        [Required]
        public string Ssn { get; set; }
        public int Score { get; set; }
        public Status Status { get; set; }
        [Required]
        public int StatusId { get; set; }
        
        public virtual IList<Document> Documents { get; set; } = new List<Document>();
    }
}