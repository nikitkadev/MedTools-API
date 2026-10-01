using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView;
using Core.Common.Results;
using Core.Dtos.RControl.Invoices;
using Core.Interfaces.Repositories.MedView;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;

using Infrastructure.Internal;
using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Implementations.Repositories.MedVIew;

public sealed class MedViewCompletedCasesRepository(
    IAvaliableKeysHelper avaliableKeysHelper,
    DbContextFactory dbContextFactory) : IMedViewCompletedCasesRepository
{
    public async Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        TargetDbType targetDb,
        CompletedCasesSearchFilters filters,
        int pageSize,
        int page,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var query = dbContext.Set<CompletedCaseDbEntity>()
            .AsNoTracking()
            .Join(
                dbContext.Set<PersonDbEntity>(),
                completedCase => new
                {
                    Registry = completedCase
                        .MedicalRecord
                        .MedicalRegistry
                        .MedicalRegistryHeading
                        .Filename,

                    Patient = completedCase
                        .MedicalRecord
                        .Patient
                        .PatientRecordCode
                },
                person => new
                {
                    Registry = person
                        .PersonRegistry
                        .PersonRegistryHeading
                        .MedicalRegistryFilename,

                    Patient = person.PatientRecordCode
                },
                (completedCase, person) => new CompletedCaseSearchRow
                {
                    CompletedCase = completedCase,
                    Person = person
                });

        query = ApplyPersonFilters(query, filters);
        query = ApplyMedicalDetailsFilters(query, filters);
        query = await ApplyOncologyFiltersAsync(query, filters);

        var count = await query.CountAsync(cancellationToken: cancellationToken);
        var records = await query
            .OrderBy(x => x.CompletedCase.Uid)
            .Skip(pageSize * (page - 1))
            .Take(pageSize)
            .Select(x => new CompletedCaseListItemDto(
                CompletedCaseUid: x.CompletedCase.Uid,
                EntryNumber: x.CompletedCase.CaseRecordNumber,
                AmountBilled: x.CompletedCase.BilledAmount,
                ApprovedAmount: x.CompletedCase.ApprovedAmount,
                InsuranceCompanyApprovedAmount: x.CompletedCase.InsuranceCompanyApprovedAmount,
                MedicalCareConditions: x.CompletedCase.CareCondition,
                PatientLastName: x.Person.PatientLastName,
                PatientFirstName: x.Person.PatientFirstName,
                PatientMiddleName: x.Person.PatientMiddleName,
                InsurancePolicySeries: x.CompletedCase.MedicalRecord.Patient.InsurancePolicySeries,
                InsurancePolicyNumber: x.CompletedCase.MedicalRecord.Patient.InsurancePolicyNumber,
                EntryPositionNumber: x.CompletedCase.MedicalRecord.RecordSequenceNumber))

            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<CompletedCaseListItemDto>(
            Records: records,
            TotalCount: count);
    }

    private static IQueryable<CompletedCaseSearchRow> ApplyPersonFilters(
        IQueryable<CompletedCaseSearchRow> query,
        CompletedCasesSearchFilters filters)
    {

        if (!string.IsNullOrWhiteSpace(filters.Person.Patient.FirstName))
        {
            query = query.Where(
                x => x.Person.PatientFirstName == filters.Person.Patient.FirstName);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Patient.LastName))
        {
            query = query.Where(
                x => x.Person.PatientLastName == filters.Person.Patient.LastName);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Patient.MiddleName))
        {
            query = query.Where(
                x => x.Person.PatientMiddleName == filters.Person.Patient.MiddleName);
        }

        if (filters.Person.Patient.BirthDate is not null)
        {
            query = query.Where(
                x => x.Person.PatientBirthDate == filters.Person.Patient.BirthDate);
        }


        if (!string.IsNullOrWhiteSpace(filters.Person.Representative.FirstName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeFirstName == filters.Person.Representative.FirstName);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Representative.LastName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeLastName == filters.Person.Representative.LastName);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Representative.MiddleName))
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeMiddleName == filters.Person.Representative.MiddleName);
        }

        if (filters.Person.Representative.BirthDate is not null)
        {
            query = query.Where(
                x => x.Person.PatientRepresentativeBirthday == filters.Person.Representative.BirthDate);
        }


        if (filters.Person.Insurance.Insurances.Count != 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsuranceCompanyCode != null
                && filters.Person.Insurance.Insurances.Contains(x.CompletedCase.MedicalRecord.Patient.InsuranceCompanyCode));
        }

        if (filters.Person.Insurance.InsurancePolicyTypes.Count != 0)
        {
            query = query.Where(
                x => filters.Person.Insurance.InsurancePolicyTypes.Contains(x.CompletedCase.MedicalRecord.Patient.InsurancePolicyType.ToString()));
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Insurance.InsurancePolicySeries))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsurancePolicySeries == filters.Person.Insurance.InsurancePolicySeries);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Insurance.InsurancePolicyNumber))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsurancePolicyNumber == filters.Person.Insurance.InsurancePolicyNumber);
        }

        if (!string.IsNullOrWhiteSpace(filters.Person.Insurance.UnifiedPolicyNumber))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalRecord.Patient.InsurancePolicyUnifiedNumber == filters.Person.Insurance.UnifiedPolicyNumber);
        }

        return query;
    }

    private static IQueryable<CompletedCaseSearchRow> ApplyMedicalDetailsFilters(
        IQueryable<CompletedCaseSearchRow> query,
        CompletedCasesSearchFilters filters)
    {
        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.MedicalProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.MedicalCaseDetails.BaseMedicalCaseDetails.MedicalProfiles.Contains(
                        medicalCase.MedicalProfile)));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.BedProfiles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.BedProfile.HasValue
                    && filters.MedicalCaseDetails.BaseMedicalCaseDetails.BedProfiles.Contains(
                        medicalCase.BedProfile.Value)));
        }

        if (!string.IsNullOrWhiteSpace(filters.MedicalCaseDetails.BaseMedicalCaseDetails.Division))
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.Division == filters.MedicalCaseDetails.BaseMedicalCaseDetails.Division));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.EncounterMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.EncounterMoCode != null
                    && filters.MedicalCaseDetails.BaseMedicalCaseDetails.EncounterMedicalOrganizations.Contains(medicalCase.EncounterMoCode)));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.VisitPurposes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.VisitPurpose != null
                    && filters.MedicalCaseDetails.BaseMedicalCaseDetails.VisitPurposes.Contains(medicalCase.VisitPurpose)));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.PreventiveCarePlaces.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.PreventiveCareMoCode.HasValue
                    && filters.MedicalCaseDetails.BaseMedicalCaseDetails.PreventiveCarePlaces.Contains(medicalCase.PreventiveCareMoCode.Value)));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.TreatmentStartDate is not null)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.TreatmentStartDate == filters.MedicalCaseDetails.BaseMedicalCaseDetails.TreatmentStartDate));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.TreatmentEndDate is not null)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.TreatmentEndDate == filters.MedicalCaseDetails.BaseMedicalCaseDetails.TreatmentEndDate));
        }

        if (!string.IsNullOrWhiteSpace(filters.MedicalCaseDetails.BaseMedicalCaseDetails.MedicalRecordNumber))
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.MedicalRecordNumber == filters.MedicalCaseDetails.BaseMedicalCaseDetails.MedicalRecordNumber));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.DiseaseCharacters.Count > 0)
        {
            query = query.Where(x => x.CompletedCase.MedicalCases.Any(
                medicalCase => medicalCase.DiseaseCharacter.HasValue
                && filters.MedicalCaseDetails.BaseMedicalCaseDetails.DiseaseCharacters.Contains(medicalCase.DiseaseCharacter.Value)));
        }

        if (filters.MedicalCaseDetails.BaseMedicalCaseDetails.PhysicianSpecialties.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => filters.MedicalCaseDetails.BaseMedicalCaseDetails.PhysicianSpecialties.Contains(medicalCase.PhysicianSpecialty)));
        }


        if (filters.MedicalCaseDetails.CompletedCaseDetails.CareConditions.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.CareConditions.Contains(
                    x.CompletedCase.CareCondition));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.CareForms.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.CareForms.Contains(
                    x.CompletedCase.CareForm));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.MedicalCareTypes.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.MedicalCareTypes.Contains(
                    x.CompletedCase.MedicalCareType));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.MedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.MedicalOrganizations.Contains(
                    x.CompletedCase.MedicalOrganizationCode));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.ReferringMedicalOrganizations.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.ReferringMedicalOrganizationCode != null
                && filters.MedicalCaseDetails.CompletedCaseDetails.ReferringMedicalOrganizations.Contains(
                    x.CompletedCase.ReferringMedicalOrganizationCode));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.TreatmentStartDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.TreatmentStartDate == filters.MedicalCaseDetails.CompletedCaseDetails.TreatmentStartDate);
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.TreatmentEndDate is not null)
        {
            query = query.Where(
                x => x.CompletedCase.TreatmentEndDate == filters.MedicalCaseDetails.CompletedCaseDetails.TreatmentEndDate);
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.DiseaseOutcomes.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.DiseaseOutcomes.Contains(
                    x.CompletedCase.DiseaseOutcome));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.ScreeningResults.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.ScreeningResult.HasValue
                && filters.MedicalCaseDetails.CompletedCaseDetails.ScreeningResults.Contains(
                    x.CompletedCase.ScreeningResult.Value));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.HospitalizationOutcomes.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.HospitalizationOutcomes.Contains(
                    x.CompletedCase.HospitalizationOutcome));
        }

        if (filters.MedicalCaseDetails.CompletedCaseDetails.PaymentMethods.Count > 0)
        {
            query = query.Where(
                x => filters.MedicalCaseDetails.CompletedCaseDetails.PaymentMethods.Contains(
                    x.CompletedCase.PaymentMethodCode));
        }

        return query;
    }

    private async Task<IQueryable<CompletedCaseSearchRow>> ApplyOncologyFiltersAsync(
        IQueryable<CompletedCaseSearchRow> query,
        CompletedCasesSearchFilters filters)
    {
        if (filters.Oncology.OncologyCase.ReferralReasons.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.ReferralReasonCode.HasValue
                    && filters.Oncology.OncologyCase.ReferralReasons.Contains(medicalCase.OncologyCase.ReferralReasonCode.Value)));
        }

        if (filters.Oncology.OncologyCase.Stages.Count > 0)
        {
            var stageKeys = await avaliableKeysHelper.GetAvailableDiseaseStageKeysAsync(filters.Oncology.OncologyCase.Stages);

            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.Stage.HasValue
                    && stageKeys.Contains(medicalCase.OncologyCase.Stage.Value)));
        }


        if (filters.Oncology.OncologyService.ServiceTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => filters.Oncology.OncologyService.ServiceTypes.Contains(
                            oncologyService.ServiceTypeCode))));
        }

        if (filters.Oncology.OncologyService.SurgicalTreatmentTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.SurgicalTreatmentTypeCode.HasValue
                        && filters.Oncology.OncologyService.SurgicalTreatmentTypes.Contains(
                            oncologyService.SurgicalTreatmentTypeCode.Value))));
        }

        if (filters.Oncology.OncologyService.RadioTherapyTypes.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.RadioTherapyTypeCode.HasValue
                        && filters.Oncology.OncologyService.RadioTherapyTypes.Contains(
                            oncologyService.RadioTherapyTypeCode.Value))));
        }

        if (filters.Oncology.OncologyService.DrugTherapyCycles.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.DrugTherapyCycleCode.HasValue
                        && filters.Oncology.OncologyService.DrugTherapyCycles.Contains(
                            oncologyService.DrugTherapyCycleCode.Value))));
        }


        if (filters.Oncology.Medication.DrugIdentifiers.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.Medications.Any(
                            medication => medication.DrugIdentifier != null
                            && filters.Oncology.Medication.DrugIdentifiers.Contains(medication.DrugIdentifier)))));
        }

        if (filters.Oncology.Medication.TherapyRegimens.Count > 0)
        {
            query = query.Where(
                x => x.CompletedCase.MedicalCases.Any(
                    medicalCase => medicalCase.OncologyCase.OncologyServices.Any(
                        oncologyService => oncologyService.Medications.Any(
                            medication => medication.TherapyRegimenCode != null
                            && filters.Oncology.Medication.TherapyRegimens.Contains(medication.TherapyRegimenCode)))));
        }

        return query;
    }

}