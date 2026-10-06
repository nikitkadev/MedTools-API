using Microsoft.EntityFrameworkCore;

using Core.Common.Enums;

namespace Infrastructure.Database.Factories;

public class DbContextFactory(
    IDbContextFactory<SMODbContext> smoDbContextFactory,
    IDbContextFactory<InogorodDbContext> inogorodDbContextFactory,
    IDbContextFactory<MedSprDbContenxt> medSprDbContextFactory)
{
    public MedToolsDbContext CreateDbContext(TargetDbType targetDb)
    {
        return targetDb switch
        {
            TargetDbType.SMODB18 => smoDbContextFactory.CreateDbContext(),
            TargetDbType.INOGOROD18 => inogorodDbContextFactory.CreateDbContext(),
            TargetDbType.MEDSPR18 => medSprDbContextFactory.CreateDbContext(),
            _ => throw new InvalidOperationException()
        };
    }
}