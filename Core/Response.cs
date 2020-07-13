using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core
{
    public class ResponseData
    {
        public string POLICY_SEQ { get; set; }
        public string CL_SEQID { get; set; }
        public string CL_DATEIN { get; set; }
        public string CL_DATEOT { get; set; }
        public string CL_PP_NO { get; set; }
        public string CL_NAME { get; set; }
        public string CL_PROV_NAME { get; set; }
        public string CL_DIAG { get; set; }
        public string CL_REJ { get; set; }
        public string CL_CLMAMT { get; set; }
        public string CL_REMK { get; set; }
        public string CL_PROVIDER { get; set; }
        public string CL_HOSFILE { get; set; }
        public string CL_ADMDATE { get; set; }
        public string CL_DISCHARGE { get; set; }
        public string CL_EXP_DISCH { get; set; }
        public string CL_RISK { get; set; }
        public string CL_DECISION { get; set; }
        public string CL_VATAMT { get; set; }
    }

    public class Response
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public IList<ResponseData> responseData { get; set; }
    }
}

