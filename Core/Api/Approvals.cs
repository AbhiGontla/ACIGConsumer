using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
    public class Approvals : BaseEntity
    {
        public string POLICY_SEQ { get; set; }
        public string CL_SEQID { get; set; }
        public DateTime CL_DATEIN { get; set; }
        public DateTime CL_DATEOT { get; set; }
        public string CL_PP_NO { get; set; }
        public string CL_NAME { get; set; }
        public string CL_PROV_NAME { get; set; }
        public string CL_DIAG { get; set; }
        public string CL_REJ { get; set; }
        public string CL_CLMAMT { get; set; }
        public string CL_REMK { get; set; }
        public string CL_PROVIDER { get; set; }
        public string CL_HOSFILE { get; set; }
        public DateTime CL_ADMDATE { get; set; }
        public DateTime CL_DISCHARGE { get; set; }
        public DateTime CL_EXP_DISCH { get; set; }
        public string CL_RISK { get; set; }
        public string CL_DECISION { get; set; }
        public string CL_VATAMT { get; set; }
        public string Code { get; set; }
        public string NationalId { get; set; }
        public string YearofBirth { get; set; }
        public string InsPolicyNo { get; set; }

    }

    public class GetApprovalsResponse
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public List<Approvals> responseData { get; set; }
    }
}
