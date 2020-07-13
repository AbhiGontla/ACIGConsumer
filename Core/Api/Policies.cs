using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
	public class Policies : BaseEntity
	{
		public string PolicyNumber { get; set; }
		public string PolicyFromDate { get; set; }
		public string PolicyToDate { get; set; }
		public string PolicyType { get; set; }
		public string ClientType { get; set; }
		public string ClassCode { get; set; }
		public string ClassName { get; set; }
		public string NetworkCode { get; set; }
		public string NetworkName { get; set; }
		public string TPAID { get; set; }
		public string TPAName { get; set; }
		public string ClientName { get; set; }
		public string PolicySponsorName { get; set; }
		public string BrokerName { get; set; }
		public string SponsorID { get; set; }
		public string Iqama_NationalID { get; set; }
		public string MemberName { get; set; }
		public string MobileNumber { get; set; }
		public string Gender { get; set; }
		public string MaritalStatus { get; set; }
		public string DOBGreg { get; set; }
		public string DOBHijri { get; set; }
		public string IDExpiryDate { get; set; }
		public string OccupationCode { get; set; }
		public string OccupationDesc { get; set; }
		public string NationalityCode { get; set; }
		public string NationalityDesc { get; set; }
		public string MemberTypeCode { get; set; }
		public string MemberTypeDesc { get; set; }
		public string RelationCode { get; set; }
		public string RelationDesc { get; set; }
		public string EmployeeNo { get; set; }
		public string MemberStatus { get; set; }
		public string TushfaMemberNo { get; set; }
		public string CardNo { get; set; }
		public string EnrollmentDate { get; set; }
		public string MigrationDate { get; set; }
		public string DeletionDate { get; set; }
		public string AdditionPremium { get; set; }
		public string MigrationPremium { get; set; }
		public string DeletionPremium { get; set; }
		public string CCHIStatus { get; set; }
		public string CCHIUploadDate { get; set; }
		public string CCHIErrorMessage { get; set; }
		public string DeletionReason { get; set; }
		public string CityCode { get; set; }
		public string CityDesc { get; set; }
		public string RegionCode { get; set; }
		public string RegionDesc { get; set; }
		public string TransDate { get; set; }
	}
	public class PolicyResponse
	{
		public string responseCode { get; set; }
		public string responseMessage { get; set; }
		public List<Policies> responseData { get; set; }
	}
}
