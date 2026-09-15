using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Interfaces.Providers.MedView.AvailableKeysProviders;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Implementations.Providers.MedView.AvailableKeysProviders;

public sealed class AvailableMedicalOrganizationKeysProvider(
    DbContextFactory dbContextFactory) : IAvailableMedicalOrganizationKeysProvider
{
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
