namespace Core.Dtos.RControl.Workspace;

public sealed record InvoiceSummaryDto(
    int InvoiceUid,
    string Filename,
    DateTime InvoiceUploadDate,
    decimal InvoiceAmount,
    decimal ApprovedAmount,
    decimal MedicalEconomicControlPenalty,
    decimal MedicalEconomicExpertisePenalty,
    decimal MedicalCareQualityExpertisePenalty,
    decimal InsuranceCompanyApprovedAmount,
    decimal InsuranceCompanyMedicalEconomicControlPenalty,
    decimal InsuranceCompanyMedicalEconomicExpertisePenalty,
    decimal InsuranceCompanyMedicalCareQualityExpertisePenalty);
