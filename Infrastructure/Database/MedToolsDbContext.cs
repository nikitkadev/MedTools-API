using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Core.Dtos.Categories.Onkology;

using Infrastructure.Database.Enitites.Auth;

namespace Infrastructure.Database;

public abstract class MedToolsDbContext(
    DbContextOptions options) : DbContext(options)
{

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<OnkSluchDto> OnkCases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public class SMODbContext(
    DbContextOptions<SMODbContext> options) : MedToolsDbContext(options);

public class InogorodDbContext(
    DbContextOptions<InogorodDbContext> options) : MedToolsDbContext(options);
