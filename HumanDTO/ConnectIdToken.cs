namespace HumanDTO
{
    public class ConnectIdToken
    {
        public string token_type { get; set; }
        public string id_token { get; set; }
        public string id_refresh_token { get; set; }
        public int id_token_expires_in { get; set; }
    }


}
