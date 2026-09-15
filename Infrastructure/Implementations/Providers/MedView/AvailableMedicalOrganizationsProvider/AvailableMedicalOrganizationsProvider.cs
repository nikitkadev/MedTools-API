using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;
using Core.Dtos.MedView.Reference;
using Core.Interfaces.Providers.MedView.AvailableOrganizationsProvider;

using Infrastructure.Database.Factories;
using Infrastructure.Database.DbEntities.References;
using Infrastructure.Database.DbEntities.InvoiceStructure.Elements;

namespace Infrastructure.Implementations.Providers.MedView.AvailableMedicalOrganizationsProvider;

public sealed class AvailableMedicalOrganizationsProvider(
    DbContextFactory dbContextFactory) : IAvailableMedicalOrganizationsProvider
{
    public async Task<IReadOnlyCollection<InsuranceReferenceDto>> GetInsuranceAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken = default)
    {
        await using var referenceDbContext = dbContextFactory.CreateDbContext(TargetDbType.MEDSPR18);
        await using var targetDbContext = dbContextFactory.CreateDbContext(targetDb: targetDb);

        var insuranceReferences = await referenceDbContext.Set<InsuranceDbEntity>()
            .ToListAsync(cancellationToken);

        var avaliableInsuranceCodes = await targetDbContext.Set<PatientDbEntity>()
            .Select(patient => patient.InsuranceCompanyCode)
            .Distinct()
            .ToListAsync(cancellationToken);

        var result = avaliableInsuranceCodes.Join(
            insuranceReferences,
            code => code,
            insurance => insurance.InsuranceCode,
            (code, insurance) => new InsuranceReferenceDto(Code: code ?? string.Empty, Name: insurance.InsuranceShortname)).ToList();

        return result;
    }
}
