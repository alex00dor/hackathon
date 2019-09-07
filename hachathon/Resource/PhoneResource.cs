using System.ComponentModel.DataAnnotations;

namespace hachathon.Resource
{
    public class PhoneResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public bool Available { get; set; }
    }
}