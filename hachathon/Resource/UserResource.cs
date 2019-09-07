using System.ComponentModel.DataAnnotations;

namespace hachathon.Resource
{
    public class UserResource
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PhoneId { get; set; }
        [Required]
        public int PlanId { get; set; }
        [Required]
        public string Ssn { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}