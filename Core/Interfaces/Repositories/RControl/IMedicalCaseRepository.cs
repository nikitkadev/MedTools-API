using Core.Common.Enums;
using Core.Common.Results;
using Core.Dtos.RControl.MedicalCases;

namespace Core.Interfaces.Repositories.RControl;

public interface IMedicalCaseRepository
{
    Task<PatientDto?> GetPatientAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<InsuranceDto?> GetInsuranceAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<ProvidedServiceListItemDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<MedicalCaseDetailsDto?> GetMedicalCaseDetailsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<ClinicalGroupDto?> GetClinicalGroupAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<HighTechMedicalCareDto?> GetHighTechMedicalCareAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<ReferralDto>> GetReferralsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<PrescriptionDto>> GetPrescriptionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<PagedResult<DefectDto>> GetDefectsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        int page,
        int pageSize,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<MedicalSanctionDto>> GetMedicalSanctionsAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);

    Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        TargetDbType targetDb,
        CancellationToken cancellationToken);
}