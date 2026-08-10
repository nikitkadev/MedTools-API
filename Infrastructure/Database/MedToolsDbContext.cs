using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Infrastructure.Database.Enitites.Auth;
using Core.Dtos.RControl.Categories.DefectsSanks;
using Core.Dtos.RControl.Categories.KsgVmp;
using Core.Dtos.RControl.Categories.NazNapr;
using Core.Dtos.RControl.Categories.Oncology;

namespace Infrastructure.Database;

public abstract class MedToolsDbContext(
    DbContextOptions options) : DbContext(options)
{

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<InjectionDto> Injections { get; set; }
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
