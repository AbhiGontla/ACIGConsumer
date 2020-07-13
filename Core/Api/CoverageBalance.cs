using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
    public class CoverageBalance:BaseEntity
    {
		public string Code { get; set; }
		public string NationalID { get; set; }
		public string YearofBirth { get; set; }
		public string InsPolicyNo { get; set; }
		public string Description { get; set; }
		public string Limit { get; set; }
		public string RemainingAmount { get; set; }
		public string Status { get; set; }
		public string LoginDate { get; set; }
		public string FromDate { get; set; }
		public string ToDate { get; set; }
	}

	public class CoverageBalanceResponse
	{
		public string responseCode { get; set; }
		public string responseMessage { get; set; }
		public List<CoverageBalance> responseData { get; set; }
	}
}
