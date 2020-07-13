using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api
{
    public class ClientDTO : BaseEntity
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }
        public string IDNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        //  public int? GenderId { get; set; }
        public string GenderName { get; set; }
        public string IBANNumber { get; set; }
        public string BankName { get; set; }

    }
    public class RequestCreateDTO : BaseEntity
    {
        public int? ClientId { get; set; }
        public string RequestNumber { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? RequestStatusId { get; set; }
        public string RequestStatusName { get; set; }
        public string PolicyNumber { get; set; }
        public string HolderName { get; set; }
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string RelationName { get; set; }
        public string ClaimTypeName { get; set; }
        public string CardNumber { get; set; }
        public DateTime? CardExpireDate { get; set; }
        public decimal? ExpectedAmount { get; set; }
        public decimal? ActualAmount { get; set; }
        public decimal? VATAmount { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string NationalId { get; set; }
        public string Comment { get; set; }

        public ClientDTO ClientDTO { get; set; }

        public List<RequestFileDTO> RequestFileList { get; set; }
    }
    public class RequestFileDTO : BaseEntity
    {
        public int FileId { get; set; }

        //  public string RequestNumber { get; set; }
        //  public string IDNumber { get; set; }
        public string FilePath { get; set; }
        public Byte[] MyFile { get; set; }
        public string FileName { get; set; }
        public string FileDesc { get; set; }
        public string Comment { get; set; }
    }
    public class ReImClaims
    {
        public int RequestId { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestStatusName { get; set; }
        public string PolicyNumber { get; set; }
        public string ClaimTypeName { get; set; }
        public double ExpectedAmount { get; set; }
        public object ActualAmount { get; set; }
        public double VATAmount { get; set; }
        public object CreateDate { get; set; }
        public ClientDTO ClientDTO { get; set; }

    }

    public class ReImClaimsResponse
    {
        public List<ReImClaims> MyArray { get; set; }

    }
}
