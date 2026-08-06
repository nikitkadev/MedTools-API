using Microsoft.EntityFrameworkCore;

using Core.Enums;

using Infrastructure.Factories;
using Core.Dtos.RControl.Lookups;
using Core.Interfaces.RControl.Repositories.Lookups;

namespace Infrastructure.Repositories.RControl.Lookups;

public class MedicalOrganizationRepository(DbContextFactory dbContextFactory) : IMedicalOrganizationRepository
{
    public async Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        var medicalOrganizations = await dbContext
            .Set<MedicalOrganizationDto>()
            .FromSqlRaw("EXEC sp26_get_mo")
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalOrganizations; 
    }
}