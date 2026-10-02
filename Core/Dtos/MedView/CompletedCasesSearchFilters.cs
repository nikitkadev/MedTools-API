namespace Core.Dtos.MedView;

public sealed class CompletedCasesSearchFilters
{
    public PersonFilters Person { get; set; } = new();
    public MedicalCaseDetailsFilters MedicalCaseDetails { get; set; } = new();
    public OncologyFilters Oncology { get; set; } = new();
    public PrescriptionFilters Prescription { get; set; } = new();
    public ClinicalGroupFilters ClinicalGroup { get; set; } = new();
    public ProvidedServiceFilters ProvidedService { get; set; } = new();
    public SanctionFilters Sanction { get; set; } = new();
    public InternalServiceFilters InternalService { get; set; } = new();
}

#region PersonFilters
public sealed class PersonFilters
{
    public PatientFilters Patient { get; set; } = new();
    public RepresentativeFilters Representative { get; set; } = new();
    public InsuranceFilters Insurance { get; set; } = new();
}

public sealed class PatientFilters
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
}

public sealed class RepresentativeFilters
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
}

public sealed class InsuranceFilters
{
    public List<string> Insurances { get; set; } = [];
    public List<string> InsurancePolicyTypes { get; set; } = [];
    public string InsurancePolicyNumber { get; set; } = string.Empty;
    public string InsurancePolicySeries { get; set; } = string.Empty;
    public string UnifiedPolicyNumber { get; set; } = string.Empty;


}
#endregion

#region MedicalCaseDetails
public sealed class MedicalCaseDetailsFilters
{
    public BaseMedicalCaseDetailsFilters BaseMedicalCaseDetails { get; set; } = new();
    public CompletedCaseDetailsFilters CompletedCaseDetails { get; set; } = new();
}

public sealed class BaseMedicalCaseDetailsFilters
{
    public List<int> MedicalProfiles { get; set; } = [];
    public List<int> BedProfiles { get; set; } = [];
    public List<byte> DiseaseCharacters { get; set; } = [];
    public string Division { get; set; } = string.Empty;
    public List<string> EncounterMedicalOrganizations { get; set; } = [];
    public string MedicalRecordNumber { get; set; } = string.Empty;
    public List<int> PhysicianSpecialties { get; set; } = [];
    public List<byte> PreventiveCarePlaces { get; set; } = [];
    public DateTime? TreatmentEndDate { get; set; }
    public DateTime? TreatmentStartDate { get; set; }
    public List<string> VisitPurposes { get; set; } = [];

}

public sealed class CompletedCaseDetailsFilters
{
    public List<int> CareConditions { get; set; } = [];
    public List<byte> CareForms { get; set; } = [];
    public List<int> DiseaseOutcomes { get; set; } = [];
    public List<int> HospitalizationOutcomes { get; set; } = [];
    public List<int> MedicalCareTypes { get; set; } = [];
    public List<string> MedicalOrganizations { get; set; } = [];
    public List<short> PaymentMethods { get; set; } = [];
    public List<string> ReferringMedicalOrganizations { get; set; } = [];
    public List<int> ScreeningResults { get; set; } = [];
    public DateTime? TreatmentEndDate { get; set; }
    public DateTime? TreatmentStartDate { get; set; }
}
#endregion

#region Oncology 
public sealed class OncologyFilters
{
    public OncologyCaseFilters OncologyCase { get; set; } = new();
    public OncologyServiceFilters OncologyService { get; set; } = new();
    public MedicationFilters Medication { get; set; } = new();
}

public sealed class OncologyCaseFilters
{
    public List<string> Stages { get; set; } = [];
    public List<byte> ReferralReasons { get; set; } = [];
}

public sealed class OncologyServiceFilters
{
    public List<byte> DrugTherapyCycles { get; set; } = [];
    public List<string> DrugTherapyLines { get; set; } = [];
    public List<byte> RadioTherapyTypes { get; set; } = [];
    public List<byte> ServiceTypes { get; set; } = [];
    public List<byte> SurgicalTreatmentTypes { get; set; } = [];
}

public sealed class MedicationFilters
{
    public List<string> DrugIdentifiers { get; set; } = [];
    public List<string> TherapyRegimens { get; set; } = [];

}
#endregion

#region PrescriptionFilters
public sealed class PrescriptionFilters
{
    public BasePrescriptionFilters BasePrescription { get; set; } = new();
    public ReferralFilters Referral { get; set; } = new();
}

public sealed class BasePrescriptionFilters
{
    public List<string> BedProfiles { get; set; } = [];
    public List<byte> DiagnosticMethods { get; set; } = [];
    public List<int> MedicalCareProfiles { get; set; } = [];
    public List<byte> PrescriptionTypes { get; set; } = [];
    public DateTime? ReferralDate { get; set; }
    public List<string> ReferredToMedicalOrganizations { get; set; } = [];
    public List<string> Services { get; set; } = [];
}

public sealed class ReferralFilters
{
    public List<byte> DiagnosticMethods { get; set; } = [];
    public DateTime? ReferralDate { get; set; }
    public List<byte> ReferralTypes { get; set; } = [];
    public List<string> ReferredServices { get; set; } = [];
    public List<string> ReferredToMedicalOrganizations { get; set; } = [];

}
#endregion

#region ClinicalGroup
public sealed class ClinicalGroupFilters
{
    public BaseClinicalGroupFilters BaseClinicalGroup { get; set; } = new();
    public HighTechMedicalCareFilters HighTechMedicalCare { get; set; } = new();
}

public sealed class BaseClinicalGroupFilters
{
    public List<string> ClinicalStatisticGroupNumbers { get; set; } = [];
    public List<string> ComplexityCoefficientNumbers { get; set; } = [];
    public List<string> InterruptedCasePaymentReasons { get; set; } = [];
}

public sealed class HighTechMedicalCareFilters
{
    public List<string> HighTechCareMethods { get; set; } = [];
    public List<string> HighTechCareTypes { get; set; } = [];
    public DateTime? PlannedAdmissionDate { get; set; }
    public DateTime? VoucherIssueDate { get; set; }
    public string VoucherNumber { get; set; } = string.Empty;
}
#endregion

#region ProvidedService
public sealed class ProvidedServiceFilters
{
    public List<string> ProvidedServices { get; set; } = [];
}
#endregion

#region Sanction
public sealed class SanctionFilters
{
    public List<string> ControlTypeCodes { get; set; } = [];
    public string ExpertiseActNumber { get; set; } = string.Empty;
    public List<int> RefusalReasons { get; set; } = [];
    public DateTime? ExpertiseActDate { get; set; }
}
#endregion

#region InternalService
public sealed class InternalServiceFilters
{
    public string CompletedCaseUid { get; set; } = string.Empty;
    public string MedicalCaseUid { get; set; } = string.Empty;
    public string PatientUid { get; set; } = string.Empty;

}
#endregion