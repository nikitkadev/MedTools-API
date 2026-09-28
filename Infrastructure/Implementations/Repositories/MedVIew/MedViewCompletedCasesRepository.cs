using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView;
using Core.Common.Results;
using Core.Dtos.RControl.Invoices;
using Core.Interfaces.Repositories.MedView;

using Infrastructure.Internal;
using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Implementations.Repositories.MedVIew;

public sealed class MedViewCompletedCasesRepository(
    DbContextFactory dbContextFactory) : IMedViewCompletedCasesRepository
{
    public async Task<PagedResult<CompletedCaseListItemDto>> GetCompletedCaseListItemsAsync(
        TargetDbType targetDb,
        CompletedCasesSearchFilters filters,
        CancellationToken cancellationToken = default)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var query = dbContext.Set<CompletedCaseDbEntity>().AsNoTracking().Join(
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

        var count = await query.CountAsync(cancellationToken: cancellationToken);
        var records = await query.Select(x => new CompletedCaseListItemDto(
                CompletedCaseUid: x.CompletedCase.Uid,
                EntryNumber: x.CompletedCase.CaseRecordNumber,
                AmountBilled: x.CompletedCase.BilledAmount,
                ApprovedAmount: x.CompletedCase.ApprovedAmount,
                InsuranceCompanyApprovedAmount: x.CompletedCase.InsuranceCompanyApprovedAmount,
                MedicalCareConditions: x.CompletedCase.CareConditions,
                PatientLastName: x.Person.PatientLastName,
                PatientFirstName: x.Person.PatientFirstName,
                PatientMiddleName: x.Person.PatientMiddleName,
                InsurancePolicySeries: x.CompletedCase.MedicalRecord.Patient.InsurancePolicySeries,
                InsurancePolicyNumber: x.CompletedCase.MedicalRecord.Patient.InsurancePolicyNumber,
                EntryPositionNumber: x.CompletedCase.MedicalRecord.RecordSequenceNumber))
            .Take(100)
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
                x => x.Person.PatientMiddleName == filters.Person.Patient.MiddleName);
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

}