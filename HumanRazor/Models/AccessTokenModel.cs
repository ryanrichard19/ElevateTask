﻿namespace HumanRazor.Models
{
    public class AccessTokenModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
    }

}
