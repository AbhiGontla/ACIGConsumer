using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Api
{
    public class ClientDTO
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
    public class RequestCreateDTO 
    {
        public int? ClientId { get; set; }
        public int RequestId { get; set; }
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
        public List<RequestStatusLogList> RequestStatusLogList { get; set; }
    }

    public class RequestStatusLogList
    {
        public int RequestId { get; set; }
        public object RequestStatusName { get; set; }
        public string Comment { get; set; }
        public object ClientName { get; set; }
        public object EntryEmpName { get; set; }
        public object CreateDate { get; set; }

    }
    public class RequestFileDTO 
    {
        

        //  public string RequestNumber { get; set; }
        //  public string IDNumber { get; set; }
        public string FilePath { get; set; }
        public Byte[] MyFile { get; set; }
   
        public string FileDesc { get; set; }
      
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
    public class MRClaimType : BaseEntity
    {
        public string ClaimTypeName { get; set; }
    }

    public class BankMaster : BaseEntity
    {
        public int BankCode { get; set; }
        public string BankNameEnglish { get; set; }
        public string BankNameArabic { get; set; }
    }
    public class AddClaimViewModel
    {
        public List<SelectListItem> _claimstypes { get; set; }
        public List<SelectListItem> _bankNames { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [AllowExtensions(Extensions = "png,jpg,jpeg,pdf", ErrorMessage = "Please select only Supported Files .pdf | .jpg")]
        [MaxFileSize(2 * 1024, ErrorMessage = "Maximum allowed file size is 2MB")]
        public List<IFormFile> FilesUploaded { get; set; }
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

        [Required(ErrorMessage = "Please select Claim Type.")]
        public string ClaimTypeName { get; set; }
        public string CardNumber { get; set; }
        public DateTime? CardExpireDate { get; set; }

        [Required(ErrorMessage = "Please Enter Amount.")]
        public decimal? ExpectedAmount { get; set; }
        public decimal? ActualAmount { get; set; }

        [Required(ErrorMessage = "Please Enter VAT Amount")]
        public decimal? VATAmount { get; set; }
        public DateTime? TransferDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string NationalId { get; set; }
        public string Comment { get; set; }

        public Client ClientDTO { get; set; }

        public List<RequestFileDTO> RequestFileList { get; set; }

    }
    public class Client
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }
        public string IDNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        //  public int? GenderId { get; set; }
        public string GenderName { get; set; }

       
        public string[] IBANNumber { get; set; }


     
        public string IB0 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB1 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB2 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB3 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB4 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB5 { get; set; }

        [Required(ErrorMessage = "Please Enter IBAN No.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter Valid IBAN No.")]
        public string IB6 { get; set; }

        [Required(ErrorMessage = "Please select Bank.")]
        public string BankName { get; set; }


    }
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            bool status = true;
            var file = value as List<IFormFile>;
            if (file == null)
            {
                status = false;
                return status;
            }
            else
            {
                foreach (var item in file)
                {
                    var bytestoKB = item.Length / 1024;
                    status = bytestoKB <= _maxFileSize;

                }
            }

            return status;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }


    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets extensions property.  
        /// </summary>  
        public string Extensions { get; set; } = "PDF,png,jpg,jpeg,pdf";

        #endregion

        #region Is valid method  

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            var file = value as List<IFormFile>;
            bool isValid = true;

            // Settings.  
            List<string> allowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            // Verification.  
            if (file != null)
            {
                foreach (var item in file)
                {

                    // Initialization.  
                    var fileName = item.FileName;

                    // Settings.  
                    isValid = allowedExtensions.Any(y => fileName.EndsWith(y));

                }
            }


            // Info  
            return isValid;
        }

        #endregion
    }


    public class ReClaimsDetails
    {
        public RequestCreateDTO RequestCreateDTO { get; set; }
        public Registration registration { get; set; }
        public List<SelectListItem> _claimstypes { get; set; }
        public List<SelectListItem> _bankNames { get; set; }

        [AllowExtensions(Extensions = "png,jpg,jpeg,pdf", ErrorMessage = "Please select only Supported Files .pdf | .jpg")]
        [MaxFileSize(2 * 1024, ErrorMessage = "Maximum allowed file size is 2MB")]
        public List<IFormFile> FilesUploaded { get; set; }
    }
}
