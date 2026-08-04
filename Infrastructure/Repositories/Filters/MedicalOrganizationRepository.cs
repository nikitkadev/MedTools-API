using Microsoft.EntityFrameworkCore;

using Core.Enums;
using Core.Dtos.Filters;
using Core.Interfaces.Repositories.Filters;

using Infrastructure.Factories;

namespace Infrastructure.Repositories.Filters;

public class MedicalOrganizationRepository(DbContextFactory dbContextFactory) : IMedicalOrganizationRepository
{
    public async Task<IReadOnlyCollection<MedicalOrganizationDto>> GetMedicalOrganizationsAsync(
        TargetDbType targetDb, 
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(targetDb);

        string expressionString = "EXEC sp26_get_mo";

        var medicalOrganizations = await dbContext
            .Set<MedicalOrganizationDto>()
            .FromSqlRaw(expressionString)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalOrganizations; 
    }
}