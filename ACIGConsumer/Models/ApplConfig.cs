using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACIGConsumer.Models
{
    public class ApplConfig
    {
        public Url Urls { get; set; }
        public BasicAuth BasicAuth { get; set; }
        public SmsConfig SmsConfig { get; set; }
    }
    
    public class Url
    {
        public string GetApprovals { get; set; }
     
    }
    public class BasicAuth
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class SmsConfig
    {
        public string url { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string senderName { get; set; }

    }
}
