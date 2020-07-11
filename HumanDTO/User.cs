using System;
using System.ComponentModel.DataAnnotations;

namespace HumanDTO
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string EmailAddress { get; set; }
    }
}
