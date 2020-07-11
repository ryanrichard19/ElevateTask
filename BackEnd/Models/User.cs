using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string EmailAddress { get; set; }
    }
}
