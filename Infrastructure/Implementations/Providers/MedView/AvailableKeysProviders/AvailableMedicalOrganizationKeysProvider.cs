using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Implementations.Providers.MedView.AvailableKeysProviders;

public sealed class AvailableMedicalOrganizationKeysProvider(
    DbContextFactory dbContextFactory) : IAvailableMedicalOrganizationKeysProvider
{
    public async Task<IReadOnlyCollection<string>> GetMedicalOrganizationsKeysAsync(
        TargetDbType targetDb,
        MedicalOrgsKeysFrom keysFrom,
        CancellationToken cancellationToken = default)
    {
        using var dbContext = dbContextFactory.CreateDbContext(targetDb: targetDb);

        return keysFrom switch
        {
            MedicalOrgsKeysFrom.CompletedCaseMedicalOrgs => await dbContext
                .Set<CompletedCaseDbEntity>()
                .Select(patient => patient.MedicalOrganizationCode)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken),

            MedicalOrgsKeysFrom.CompletedCaseReferringMedicalOrgs => await dbContext
                .Set<CompletedCaseDbEntity>()
                .Where(x => x.ReferringMedicalOrganizationCode != null)
                .Select(patient => patient.ReferringMedicalOrganizationCode!)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken),

            MedicalOrgsKeysFrom.PrescriptionReferredToMedicalOrgs => await dbContext
                .Set<PrescriptionDbEntity>()
                .Where(x => x.ReferredToMoCode != null)
                .Select(prescription => prescription.ReferredToMoCode!)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken),

            MedicalOrgsKeysFrom.ReferralMedicalOrgs => await dbContext
                .Set<ReferralDbEntity>()
                .Where(x => x.ReferredToMoCode != null)
                .Select(x => x.ReferredToMoCode!)
                .Distinct()
                .ToListAsync(cancellationToken: cancellationToken),

            _ => [],
        };
    }

    public async Task<IReadOnlyCollection<string>> GetInsuranceOrganizationsKeysAsync(
        TargetDbType targetDb,
        CancellationToken cancellationToken = default)
    {
        using var dbContext = dbContextFactory.CreateDbContext(targetDb: targetDb);

        return await dbContext
            .Set<PatientDbEntity>()
            .Where(patient => patient.InsuranceCompanyCode != null)
            .Select(patient => patient.InsuranceCompanyCode!)
            .Distinct()
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
