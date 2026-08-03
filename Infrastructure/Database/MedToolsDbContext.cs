using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Core.Dtos.Categories.KsgVmp;
using Core.Dtos.Categories.NazNapr;
using Core.Dtos.Categories.Oncology;
using Core.Dtos.Categories.DefectsSanks;
using Core.Dtos.Categories.ProvidedServices;

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
    public DbSet<InjDateDto> InjDates { get; set; }
    public DbSet<InjectionDto> Injections { get; set; }
    public DbSet<ProvidedServiceDto> ProvidedServices { get; set; }
    public DbSet<MedDevDto> MedDevs { get; set; }
    public DbSet<KsgKpgDto> KsgKpgs { get; set; }
    public DbSet<VmpDto> Vmps { get; set; }
    public DbSet<CritDto> Crits { get; set; }
    public DbSet<SlKoefDto> SlKoefs { get; set; }
    public DbSet<PurposeDto> Purposes { get; set; }
    public DbSet<DirectionDto> Directions { get; set; }
    public DbSet<SankDto> Sanks { get; set; }
    public DbSet<DefectDto> Defects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

public class SMODbContext(
    DbContextOptions<SMODbContext> options) : MedToolsDbContext(options);

public class InogorodDbContext(
    DbContextOptions<InogorodDbContext> options) : MedToolsDbContext(options);
