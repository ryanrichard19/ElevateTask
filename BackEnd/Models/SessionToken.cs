namespace BackEnd.Models
{
    public class SessionToken : HumanDTO.SessionToken
    {
        public string RefreshToken { get; set; }
    }
}
