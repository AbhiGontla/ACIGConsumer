using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
	public class PaidClaims : BaseEntity
	{
		public string Code { get; set; }
		public string NationalID { get; set; }
		public string YearofBirth { get; set; }
		public string InsPolicyNo { get; set; }
		public string CL_STATUS { get; set; }
		public string CL_COUNTRY { get; set; }
		public string CL_COMPANY { get; set; }
		public string CL_SEQID { get; set; }
		public string CL_VISA_CODE { get; set; }
		public string CL_VISA { get; set; }
		public string CL_VISA_STS { get; set; }
		public string CL_ADMDATE { get; set; }
		public string CL_DCLDTE { get; set; }
		public string POLICY_SEQ { get; set; }
		public string CL_PP_NO { get; set; }
		public string CL_ClASS { get; set; }
		public string CL_RISK { get; set; }
		public string CL_SUBRISK { get; set; }
		public string CL_SUBADM { get; set; }
		public string CL_DISCHARGE { get; set; }
		public string CL_PROVIDERTYPE { get; set; }
		public string CL_PROVIDERNO { get; set; }
		public string CL_CURR { get; set; }
		public string CL_INV_DATE { get; set; }
		public string CL_BATCH { get; set; }
		public string CL_DIAG { get; set; }
		public string CL_DIAG_DESC { get; set; }
		public string CL_INV_NO { get; set; }
		public string CL_ACCIDATE { get; set; }
		public string CL_CLMAMT_OR { get; set; }
		public string CL_CLMAMT_LL { get; set; }
		public string CL_STSER { get; set; }
		public string CL_PROD { get; set; }
		public string CL_STLDATE { get; set; }
		public string CL_INV_RDATE { get; set; }
		public string CL_PAIDAMT_OR { get; set; }
		public string CL_PAIDAMT_LL { get; set; }
		public string CL_HOSPAMT_OR { get; set; }
		public string CL_HOSPAMT_LL { get; set; }
		public string CL_CALCAMT_OR { get; set; }
		public string CL_CALCAMT_LL { get; set; }
		public string CL_PAYABLE_OR { get; set; }
		public string CL_PAYABLE_LL { get; set; }
		public string CL_DEDCTN_OR { get; set; }
		public string CL_DEDCTN_LL { get; set; }
		public string CL_DEDCTBL_OR { get; set; }
		public string CL_DEDCTBL_LL { get; set; }
		public DateTime CL_SYSDATE { get; set; }
		public string CL_FSTVSA { get; set; }
		public string CL_CCHINO { get; set; }
		public string CL_CLMTYPE { get; set; }
		public string CL_SRVC { get; set; }
		public string CL_DEDREASON { get; set; }
		public string CL_INSPOLNO { get; set; }
		public string CL_INSINSURD { get; set; }
		public string CL_PROVNAME { get; set; }
		public string CL_BATCH_STS { get; set; }
		public string CL_TRFTUI { get; set; }
		public string CL_SUBOFF { get; set; }
		public string CL_FILENO { get; set; }
		public string CL_DEDMED { get; set; }
		public string CL_DEDPROV { get; set; }
		public string CL_FTYPE { get; set; }
		public string CL_VATAMT { get; set; }
		public string CL_VATNET { get; set; }
		public string SRV_DESC { get; set; }
		public string SERIAL { get; set; }
		public string GROSS_OR { get; set; }
		public string GROSS_LL { get; set; }
		public string NETPAYABLE_OR { get; set; }
		public string NETPAYABLE_LL { get; set; }
		public string ADM_TYPE { get; set; }
		public string POLICY_INC { get; set; }
		public string PROVIDER_CITY { get; set; }
		public string EMERGENCY_CHK { get; set; }
		public string CONGINATAL_CHK { get; set; }
		public string PRE_DISEASE_CHK { get; set; }
		public string LOGINDATE { get; set; }
		public string FROMDATE { get; set; }
		public string TODATE { get; set; }
		public string STATUS { get; set; }
	}
	public class PaidClaimsResponse
	{
		public string responseCode { get; set; }
		public string responseMessage { get; set; }
		public List<PaidClaims> responseData { get; set; }
	}
	public class ClaimsResponse
	{
		public List<PaidClaims> PaidClaims { get; set; }
		public List<OSClaims> OSClaims { get; set; }
	}
	public class ProviderClaimsDetails
    {
		public PaidClaims paidClaims { get; set; }
		public Registration registration { get; set; }
	}

	public class ProviderOSClaimsDetails
	{
		public OSClaims OSClaims { get; set; }
		public Registration registration { get; set; }
	}
}
