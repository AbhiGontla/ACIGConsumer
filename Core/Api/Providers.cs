using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
    public class Providers:BaseEntity
    {		
		public string Code { get; set; }
		public string NationalID { get; set; }
		public string YearofBirth { get; set; }
		public string InsPolicyNo { get; set; }
		public string ProviderType { get; set; }
		public string ProviderNumber { get; set; }
		public string ProviderName { get; set; }
		public string CCHINumber { get; set; }
		public string CCHIExpiryDate { get; set; }
		public string ProviderStatus { get; set; }
		public string Status { get; set; }
		public string FromDate { get; set; }
		public string Todate { get; set; }
		public string LoginDate { get; set; }
	}
	public class ProvidersResponse
	{
		public string responseCode { get; set; }
		public string responseMessage { get; set; }
		public List<Providers> responseData { get; set; }
	}
}
