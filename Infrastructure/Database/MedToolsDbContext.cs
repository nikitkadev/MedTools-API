using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Core.Dtos.Categories.Oncology;

using Infrastructure.Database.Enitites.Auth;

namespace Infrastructure.Database;

public abstract class MedToolsDbContext(
    DbContextOptions options) : DbContext(options)
{

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<OncSluchDto> OncCases { get; set; }
    public DbSet<ConsultationDto> Consultations { get; set; }
    public DbSet<OncologyServiceDto> OncologyServices { get; set; }
    public DbSet<OncologyContraindicationDto> Сontraindications { get; set; }
    public DbSet<DiagDto> Diags { get; set; }
    public DbSet<MedicamentDto> Medicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public class SMODbContext(
    DbContextOptions<SMODbContext> options) : MedToolsDbContext(options);

public class InogorodDbContext(
    DbContextOptions<InogorodDbContext> options) : MedToolsDbContext(options);
