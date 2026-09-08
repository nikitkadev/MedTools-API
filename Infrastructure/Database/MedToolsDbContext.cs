using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Infrastructure.Database.DbEntities;

namespace Infrastructure.Database;

public abstract class MedToolsDbContext(
    DbContextOptions options) : DbContext(options)
{
    public DbSet<UserDbEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public class SMODbContext(
    DbContextOptions<SMODbContext> options) : MedToolsDbContext(options);

public class InogorodDbContext(
    DbContextOptions<InogorodDbContext> options) : MedToolsDbContext(options);
