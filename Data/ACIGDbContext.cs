using Core.Api;
using Core.Domain;
using Core.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ACIGDbContext : DbContext
    {
        
        public ACIGDbContext()
        {

        }
        public ACIGDbContext(DbContextOptions<ACIGDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=DESKTOP-D4V62HB;Initial Catalog=ACIG;Trusted_Connection=True;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.Property(e => e.FirstName).HasMaxLength(50);

                builder.Property(e => e.MiddleName).HasMaxLength(50);

                builder.Property(e => e.LastName).HasMaxLength(50);

                builder.Property(e => e.EmailId).HasMaxLength(50);

                builder.Property(e => e.MobileNumber).HasMaxLength(50);


            });
            modelBuilder.Entity<Registration>(builder =>
            {  
                builder.Property(e => e.Id);
                builder.Property(e => e.DOB);
                builder.Property(e => e.MemberName);
                builder.Property(e => e.MemberMobileNumber);
                builder.Property(e => e.MemberStatus);
                builder.Property(e => e.MemberType);
                builder.Property(e => e.TPAID);
                builder.Property(e => e.TPAName);
                builder.Property(e => e.PolicyNo);
                builder.Property(e => e.PolicyFromDate);
                builder.Property(e => e.PolicyToDate);
                builder.Property(e => e.TushfaMemberNo);
                builder.Property(e => e.CardNo);
                builder.Property(e => e.PhoneNoVerification); 
                builder.Property(e => e.CreatePin);
                builder.Property(e => e.ConfirmPin);
                builder.Property(e => e.LoginDateandTime);
                builder.Property(e => e.Iqama_NationalID);
            });
            //Registration Table
            modelBuilder.Entity<Approvals>(builder =>
            {
                builder.Property(e => e.CL_ADMDATE);
                builder.Property(e => e.CL_CLMAMT);
                builder.Property(e => e.CL_DATEIN);
                builder.Property(e => e.CL_DATEOT);
                builder.Property(e => e.CL_DECISION);
                builder.Property(e => e.CL_DIAG);
                builder.Property(e => e.CL_DISCHARGE);
                builder.Property(e => e.CL_EXP_DISCH);
                builder.Property(e => e.CL_HOSFILE);
                builder.Property(e => e.CL_NAME);
                builder.Property(e => e.CL_PP_NO);
                builder.Property(e => e.CL_PROVIDER);
                builder.Property(e => e.CL_PROV_NAME);
                builder.Property(e => e.CL_REJ);
                builder.Property(e => e.CL_REMK);
                builder.Property(e => e.CL_RISK);
                builder.Property(e => e.CL_SEQID);
                builder.Property(e => e.CL_VATAMT);
                builder.Property(e => e.Code);
                builder.Property(e => e.Id);
                builder.Property(e => e.InsPolicyNo);
                builder.Property(e => e.NationalId);
                builder.Property(e => e.POLICY_SEQ);
                builder.Property(e => e.YearofBirth);
            });
            //Policies Table
            modelBuilder.Entity<Policies>(builder =>
            {
                builder.Property(e => e.AdditionPremium);
                builder.Property(e => e.BrokerName);
                builder.Property(e => e.CardNo);
                builder.Property(e => e.CCHIErrorMessage);
                builder.Property(e => e.CCHIStatus);
                builder.Property(e => e.CCHIUploadDate);
                builder.Property(e => e.CityCode);
                builder.Property(e => e.CityDesc);
                builder.Property(e => e.ClassCode);
                builder.Property(e => e.ClassName);
                builder.Property(e => e.ClientName);
                builder.Property(e => e.ClientType);
                builder.Property(e => e.DeletionDate);
                builder.Property(e => e.DeletionPremium);
                builder.Property(e => e.DeletionReason);
                builder.Property(e => e.DOBGreg);
                builder.Property(e => e.DOBHijri);
                builder.Property(e => e.EmployeeNo);
                builder.Property(e => e.EnrollmentDate);
                builder.Property(e => e.Gender);
                builder.Property(e => e.Id);
                builder.Property(e => e.IDExpiryDate);
                builder.Property(e => e.Iqama_NationalID);
                builder.Property(e => e.MaritalStatus);
                builder.Property(e => e.MemberName);
                builder.Property(e => e.MemberStatus);
                builder.Property(e => e.MemberTypeCode);
                builder.Property(e => e.MemberTypeDesc);
                builder.Property(e => e.MigrationDate);
                builder.Property(e => e.MigrationPremium);
                builder.Property(e => e.MobileNumber);
                builder.Property(e => e.NationalityCode);
                builder.Property(e => e.NationalityDesc);
                builder.Property(e => e.NetworkCode);
                builder.Property(e => e.NetworkName);
                builder.Property(e => e.OccupationCode);
                builder.Property(e => e.OccupationDesc);
                builder.Property(e => e.PolicyFromDate);
                builder.Property(e => e.PolicyNumber);
                builder.Property(e => e.PolicySponsorName);
                builder.Property(e => e.PolicyToDate);
                builder.Property(e => e.PolicyType);
                builder.Property(e => e.RegionCode);
                builder.Property(e => e.RegionDesc);
                builder.Property(e => e.RelationCode);
                builder.Property(e => e.RelationDesc);
                builder.Property(e => e.SponsorID);
                builder.Property(e => e.TPAID);
                builder.Property(e => e.TPAName);
                builder.Property(e => e.TransDate);
                builder.Property(e => e.TushfaMemberNo);
            });
            //CoverageBalance Table
            modelBuilder.Entity<CoverageBalance>(builder =>
            {
                builder.Property(e => e.Code);
                builder.Property(e => e.Id);
                builder.Property(e => e.InsPolicyNo);
                builder.Property(e => e.NationalID);
                builder.Property(e => e.Description);
                builder.Property(e => e.Limit);
                builder.Property(e => e.RemainingAmount);
                builder.Property(e => e.YearofBirth);
            });
            //Providers Table
            modelBuilder.Entity<Providers>(builder =>
            {
                builder.Property(e => e.Code);
                builder.Property(e => e.Id);
                builder.Property(e => e.InsPolicyNo);
                builder.Property(e => e.NationalID);
                builder.Property(e => e.YearofBirth);
                builder.Property(e => e.ProviderName);
                builder.Property(e => e.ProviderNumber);
                builder.Property(e => e.ProviderStatus);
                builder.Property(e => e.ProviderType);
                builder.Property(e => e.CCHINumber);
                builder.Property(e => e.CCHIExpiryDate);
                builder.Property(e => e.Status);

            });
            //PaidClaims
            modelBuilder.Entity<PaidClaims>(builder =>
            {
                builder.Property(e => e.ADM_TYPE);
                builder.Property(e => e.CL_ACCIDATE);
                builder.Property(e => e.CL_ADMDATE);
                builder.Property(e => e.CL_BATCH);
                builder.Property(e => e.CL_BATCH_STS);
                builder.Property(e => e.CL_CALCAMT_LL);
                builder.Property(e => e.CL_CALCAMT_OR);
                builder.Property(e => e.CL_CCHINO);
                builder.Property(e => e.CL_ClASS);
                builder.Property(e => e.CL_CLMAMT_LL);
                builder.Property(e => e.CL_CLMAMT_OR);
                builder.Property(e => e.CL_CLMTYPE);
                builder.Property(e => e.CL_COMPANY);
                builder.Property(e => e.CL_COUNTRY);
                builder.Property(e => e.CL_CURR);
                builder.Property(e => e.CL_DCLDTE);
                builder.Property(e => e.CL_DEDCTBL_LL);
                builder.Property(e => e.CL_DEDCTBL_OR);
                builder.Property(e => e.CL_DEDCTN_LL);
                builder.Property(e => e.CL_DEDCTN_OR);
                builder.Property(e => e.CL_DEDMED);
                builder.Property(e => e.CL_DEDPROV);
                builder.Property(e => e.CL_DEDREASON);
                builder.Property(e => e.CL_DIAG);
                builder.Property(e => e.CL_DIAG_DESC);
                builder.Property(e => e.CL_DISCHARGE);
                builder.Property(e => e.CL_FILENO);
                builder.Property(e => e.CL_FSTVSA);
                builder.Property(e => e.CL_FTYPE);
                builder.Property(e => e.CL_HOSPAMT_LL);
                builder.Property(e => e.CL_HOSPAMT_OR);
                builder.Property(e => e.CL_INSINSURD);
                builder.Property(e => e.CL_INSPOLNO);
                builder.Property(e => e.CL_INV_DATE);
                builder.Property(e => e.CL_INV_NO);
                builder.Property(e => e.CL_INV_RDATE);
                builder.Property(e => e.CL_PAIDAMT_LL);
                builder.Property(e => e.CL_PAIDAMT_OR);
                builder.Property(e => e.CL_PAYABLE_LL);
                builder.Property(e => e.CL_PAYABLE_OR);
                builder.Property(e => e.CL_PP_NO);
                builder.Property(e => e.CL_PROD);
                builder.Property(e => e.CL_PROVIDERNO);
                builder.Property(e => e.CL_PROVIDERTYPE);
                builder.Property(e => e.CL_PROVNAME);
                builder.Property(e => e.CL_RISK);
                builder.Property(e => e.CL_SEQID);
                builder.Property(e => e.CL_SRVC);
                builder.Property(e => e.CL_STATUS);
                builder.Property(e => e.CL_STLDATE);
                builder.Property(e => e.CL_STSER);
                builder.Property(e => e.CL_SUBADM);
                builder.Property(e => e.CL_SUBOFF);
                builder.Property(e => e.CL_SUBRISK);
                builder.Property(e => e.CL_SYSDATE);
                builder.Property(e => e.CL_TRFTUI);
                builder.Property(e => e.CL_VATAMT);
                builder.Property(e => e.CL_VATNET);
                builder.Property(e => e.CL_VISA);
                builder.Property(e => e.CL_VISA_CODE);
                builder.Property(e => e.CL_VISA_STS);
                builder.Property(e => e.Code);
                builder.Property(e => e.CONGINATAL_CHK);
                builder.Property(e => e.EMERGENCY_CHK);
                builder.Property(e => e.FROMDATE);
                builder.Property(e => e.GROSS_LL);
                builder.Property(e => e.GROSS_OR);
                builder.Property(e => e.Id);
                builder.Property(e => e.InsPolicyNo);
                builder.Property(e => e.LOGINDATE);
                builder.Property(e => e.NationalID);
                builder.Property(e => e.NETPAYABLE_LL);
                builder.Property(e => e.NETPAYABLE_OR);
                builder.Property(e => e.POLICY_INC);
                builder.Property(e => e.POLICY_SEQ);
                builder.Property(e => e.PRE_DISEASE_CHK);
                builder.Property(e => e.PROVIDER_CITY);
                builder.Property(e => e.SERIAL);
                builder.Property(e => e.SRV_DESC);
                builder.Property(e => e.STATUS);
                builder.Property(e => e.TODATE);
                builder.Property(e => e.YearofBirth);
            });
            //OSClaims
            modelBuilder.Entity<OSClaims>(builder =>
            {
                builder.Property(e => e.ADM_TYPE);
                builder.Property(e => e.CL_ACCIDT);
                builder.Property(e => e.CL_ADMDATE);
                builder.Property(e => e.CL_BATCH);
                builder.Property(e => e.CL_BATCH_STS);
                builder.Property(e => e.CL_CALCAMT_LL);
                builder.Property(e => e.CL_CALCAMT_OR);
                builder.Property(e => e.CL_CCHINO);
                builder.Property(e => e.CL_CLASS);
                builder.Property(e => e.CL_CLMAMT_LL);
                builder.Property(e => e.CL_CLMAMT_OR);
                builder.Property(e => e.CL_CLMTYPE);
                builder.Property(e => e.CL_COUNTRY);
                builder.Property(e => e.CL_CURR);
                builder.Property(e => e.CL_DCLDTE);
                builder.Property(e => e.CL_DEDCTBL_LL);
                builder.Property(e => e.CL_DEDCTBL_OR);
                builder.Property(e => e.CL_DEDCTN_LL);
                builder.Property(e => e.CL_DEDCTN_OR);
                builder.Property(e => e.CL_DEDMED);
                builder.Property(e => e.CL_DEDPROV);
                builder.Property(e => e.CL_DEDREASON);
                builder.Property(e => e.CL_DIAG);
                builder.Property(e => e.CL_DIAG_DESC);
                builder.Property(e => e.CL_DISCHARGE);
                builder.Property(e => e.CL_FILENO);
                builder.Property(e => e.CL_FSTVSA);
                builder.Property(e => e.CL_FTYPE);
                builder.Property(e => e.CL_HOSPAMT_LL);
                builder.Property(e => e.CL_HOSPAMT_OR);
                builder.Property(e => e.CL_INSINSURD);
                builder.Property(e => e.CL_INSPOLNO);
                builder.Property(e => e.CL_INV_DATE);
                builder.Property(e => e.CL_INV_NO);
                builder.Property(e => e.CL_INV_RDATE);
                builder.Property(e => e.CL_PAIDAMT_LL);
                builder.Property(e => e.CL_PAIDAMT_OR);
                builder.Property(e => e.CL_PAYABLE_LL);
                builder.Property(e => e.CL_PAYABLE_OR);
                builder.Property(e => e.CL_PP_NO);
                builder.Property(e => e.CL_PROD);
                builder.Property(e => e.CL_PROVIDER_NO);
                builder.Property(e => e.CL_PROVIDER_TYPE);
                builder.Property(e => e.CL_PROVNAME);
                builder.Property(e => e.CL_RISK);
                builder.Property(e => e.CL_SEQID);
                builder.Property(e => e.CL_SRVC);
                builder.Property(e => e.CL_STATUS);
                builder.Property(e => e.CL_STLDATE);
                builder.Property(e => e.CL_STSER);
                builder.Property(e => e.CL_SUBADM);
                builder.Property(e => e.CL_SUBOFF);
                builder.Property(e => e.CL_SUBRISK);
                builder.Property(e => e.CL_SYSDATE);
                builder.Property(e => e.CL_TRFTUI);
                builder.Property(e => e.CL_VATAMT);
                builder.Property(e => e.CL_VATNET);
                builder.Property(e => e.CL_VISA);
                builder.Property(e => e.CL_VISA_CODE);
                builder.Property(e => e.CL_VISA_STS);
                builder.Property(e => e.Code);
                builder.Property(e => e.CONGINATAL_CHK);
                builder.Property(e => e.EMERGENCY_CHK);
                builder.Property(e => e.FROM_DATE);
                builder.Property(e => e.GROSS_LL);
                builder.Property(e => e.GROSS_OR);
                builder.Property(e => e.Id);
                builder.Property(e => e.InsPolicyNo);
                builder.Property(e => e.LOGIN_DATE);
                builder.Property(e => e.NationalID);
                builder.Property(e => e.NETPAYABLE_LL);
                builder.Property(e => e.NETPAYABLE_OR);
                builder.Property(e => e.POLICY_INC);
                builder.Property(e => e.POLICY_SEQ);
                builder.Property(e => e.PRE_DISEASE_CHK);
                builder.Property(e => e.PROVIDER_CITY);
                builder.Property(e => e.SERIAL);
                builder.Property(e => e.SRV_DESC);
                builder.Property(e => e.STATUS);
                builder.Property(e => e.TO_DATE);
                builder.Property(e => e.YearofBirth);
            });
            modelBuilder.Entity<MRClaimType>(builder =>
            {
                builder.Property(e => e.Id);
                builder.Property(e => e.ClaimTypeName);

            });
            modelBuilder.Entity<BankMaster>(builder =>
            {
                builder.Property(e => e.Id);
                builder.Property(e => e.BankCode);
                builder.Property(e => e.BankNameArabic);
                builder.Property(e => e.BankNameEnglish);

            });
        }
    }
}
