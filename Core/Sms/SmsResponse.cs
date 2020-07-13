using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Sms
{    
    public class RequestStatus
    {
        public int RequestID { get; set; }
        public string ClientMessageID { get; set; }
        public string ResponseText { get; set; }
    }

    public class SmsResponse
    {
        public RequestStatus requestStatus { get; set; }
        public string invalidRecipients { get; set; }
        public string notSentTryAgain { get; set; }
        public List<object> errors { get; set; }
    }

}
