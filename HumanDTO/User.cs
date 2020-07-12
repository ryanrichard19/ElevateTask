using System.ComponentModel.DataAnnotations;

namespace HumanDTO
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string EmailAddress { get; set; }
    }

}
