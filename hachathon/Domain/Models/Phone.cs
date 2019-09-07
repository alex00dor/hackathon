using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace hachathon.Domain.Models
{
    public class Phone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Phone]
        public string Number { get; set; }

        [DefaultValue(true)]
        public bool Available { get; set; }
        
        public User User { get; set; }
    }
}