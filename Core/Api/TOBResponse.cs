using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Api
{
    public class TOBlist : BaseEntity
    {
        public string ClassName { get; set; }
        public string InsuranceClass { get; set; }
        public string GeographicalLimit { get; set; }
        public string Network { get; set; }
        public string MemberAnnualLimit { get; set; }
        public string PreExChrCondition { get; set; }

    }

    public class Inpatient : BaseEntity
    {
        public string ClassName { get; set; }
        public string RoomType { get; set; }
        public string RoomDayLimit { get; set; }
        public string Accommodation { get; set; }
        public string Surgical { get; set; }
        public string MedicalNursing { get; set; }
        public string Servicessupplies { get; set; }
        public string IntensiveCareUnit { get; set; }
        public string parentaccommodation { get; set; }
        public string Co_insurance_Deductible { get; set; }

    }

    public class Outpatient : BaseEntity
    {
        public string ClassName { get; set; }
        public string Consultations { get; set; }
        public string Diagnosticprocedures { get; set; }
        public string Prescribeddrugs { get; set; }
        public string Radiotherapy { get; set; }
        public string Physiotherapy { get; set; }
        public string MPN { get; set; }
        public string OHN { get; set; }
        public string OCN { get; set; }

    }

    public class MaternityBenefit : BaseEntity
    {
        public string ClassName { get; set; }
        public string Maternity_SubLimit { get; set; }
        public string NormalDelivery { get; set; }
        public string Caesarian { get; set; }
        public string Miscarriage { get; set; }
        public string WaitingPeriod { get; set; }
        public string coverageofnewborns { get; set; }
        public string PrematureBabies { get; set; }
        public string MaternityInpatient { get; set; }

    }

    public class DentalBenefit : BaseEntity
    {
        public string ClassName { get; set; }
        public string DentalConsultation { get; set; }
        public string Extraction { get; set; }
        public string X_Ray { get; set; }
        public string Filling { get; set; }
        public string RootCanalTreatment { get; set; }
        public string GumInfectionTreatment { get; set; }
        public string MaximumDentalSubLimit { get; set; }

    }

    public class ReimbursementClaim : BaseEntity
    {
        public string ClassName { get; set; }
        public string EmgTreatmentOutside { get; set; }
        public string NonEmgTreatmentOutside { get; set; }
        public string EmgExpensesOutside { get; set; }
        public string ConsGeneralPractitioner { get; set; }
        public string Specialist_2 { get; set; }
        public string Specialist_1 { get; set; }
        public string Consultant { get; set; }
        public string ConsultantforScarcity { get; set; }

    }

    public class AdditionalBenefit : BaseEntity
    {
        public string ClassName { get; set; }
        public string OpticalAids { get; set; }
        public string HearingAids { get; set; }
        public string KidneyDialysis { get; set; }
        public string Acute_NonAcuteTreatment { get; set; }
        public string Costsofacquiredheart { get; set; }
        public string processoforgandonation { get; set; }
        public string CostsofAlzheimer { get; set; }
        public string Costsofautismcases { get; set; }
        public string nationalprogramscreening { get; set; }
        public string CostsofdisabilityCases { get; set; }
        public string CongenitalDeformities { get; set; }
        public string Circumcision { get; set; }
        public string EarPiercing { get; set; }
        public string LocAmbulanceCharges { get; set; }
        public string mortalremainstoSaudi { get; set; }
        public string coveringmorbidobesitytreatment { get; set; }

    }

    public class TOBsublist : BaseEntity
    {
        //use not mapped when no relationship is maintained
        [NotMapped]
        public virtual List<Inpatient> Inpatient { get; set; }
        [NotMapped]
        public virtual List<Outpatient> Outpatient { get; set; }
        [NotMapped]
        public virtual List<MaternityBenefit> MaternityBenefits { get; set; }
        [NotMapped]
        public virtual List<DentalBenefit> DentalBenefits { get; set; }
        [NotMapped]
        public virtual List<ReimbursementClaim> ReimbursementClaims { get; set; }
        [NotMapped]
        public virtual List<AdditionalBenefit> AdditionalBenefits { get; set; }

    }

    public class TOB : BaseEntity
    {
        public int PolicyNo { get; set; }
        public string PolicyFromDate { get; set; }
        public string PolicyToDate { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string Network { get; set; }

        [NotMapped]
        public List<object> Errors { get; set; }

        [NotMapped]
        public virtual List<TOBlist> TOBlist { get; set; }

        [NotMapped]
        public virtual List<TOBsublist> TOBsublist { get; set; }

    }


    public class TOBResponse
    {
        public string responseCode { get; set; }
        public TOB responseData { get; set; }
        public string responseMessage { get; set; }
    }
}
