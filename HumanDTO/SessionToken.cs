using System.ComponentModel.DataAnnotations;

namespace HumanDTO
{
    public class SessionToken : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string UserId { get; set; }
        public string HumanId { get; set; }
        public string AuthToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
