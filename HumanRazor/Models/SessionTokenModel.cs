using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanRazor.Models
{
    public class SessionTokenModel
    {
        public int expires_in { get; set; }
        public string human_id { get; set; }
        public string session_token { get; set; }
    }

}
