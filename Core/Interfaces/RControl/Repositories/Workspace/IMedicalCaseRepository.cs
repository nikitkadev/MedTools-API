using Core.Enums;
using Core.Dtos.RControl.Workspace;
using Core.Dtos.RControl.Categories.MedicalCase;
using System.Reflection;
using Core.Common;

namespace Core.Interfaces.RControl.Repositories.Workspace;

public interface IMedicalCaseRepository
{
    Task<IReadOnlyCollection<MedicalCaseListItemDto>> GetMedicalCaseListItemsAsync(
        int completedCaseUid,
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
}