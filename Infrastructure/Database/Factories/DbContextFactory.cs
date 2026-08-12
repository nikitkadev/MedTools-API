using Microsoft.EntityFrameworkCore;

using Infrastructure.Database;
using Core.Common.Enums;

namespace Infrastructure.Database.Factories;

public class DbContextFactory(
    IDbContextFactory<SMODbContext> smoDbContextFactory,
    IDbContextFactory<InogorodDbContext> inogorodDbContextFactory)
{
    public MedToolsDbContext CreateDbContext(TargetDbType targetDb)
    {
        return targetDb switch
        {
            TargetDbType.SMODB18 => smoDbContextFactory.CreateDbContext(),
            TargetDbType.INOGOROD18 => inogorodDbContextFactory.CreateDbContext(),
            _ => throw new InvalidOperationException()
        };
    }
}