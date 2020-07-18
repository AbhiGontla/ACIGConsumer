using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
    class AddClaimsRequest
    {
    }

    public class UpdateClaimRequest
    {
        public int RequestId { get; set; }
        public string Comment { get; set; }
        public List<RequestFileDTO> RequestFileList { get; set; }
    }
}
