using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Core.Interfaces.Auth;
using Core.Interfaces.Repositories.Users;
using Core.Interfaces.Repositories.Categories;

using Application;

using Infrastructure.Mapping;
using Infrastructure.Options;
using Infrastructure.Services;
using Infrastructure.Database;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Categories;

using Web.Mapping;
using Web.Options;
using Core.Interfaces.RControl.Repositories.Lookups;
using Core.Interfaces.RControl.Repositories.Workspace;
using Infrastructure.Repositories.RControl.Lookups;
using Infrastructure.Repositories.RControl.Workspace;
using Core.Interfaces.RControl.Repositories.Categories;
using Infrastructure.Repositories.RControl.Categories;
using Core.Interfaces.RControl.Repositories.Oncology;
using Infrastructure.Repositories.RControl.Oncology;
using Core.Interfaces.RControl.Repositories;
using Infrastructure.Repositories.RControl.ProvidedServices;
using Core.Interfaces.RControl.Repositories.ClinicalGroups;
using Infrastructure.Repositories.RControl.ClinicalGroups;



namespace Web.Registration.DI;

public static class DependencyInjectionRegistrator
{
    public static IServiceCollection RegistrateAppServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCoreServices();
        services.AddApplicationServices();
        services.AddInfrastructureServices(configuration);
        services.AddWebServices(configuration);

        return services;
    }


    private static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IBillingPeriodRepository, BillingPeriodRepository>();
        services.AddScoped<ICompletedCaseRepository, CompletedCaseRepository>();
        services.AddScoped<IMedicalOrganizationRepository, MedicalOrganizationRepository>();
        services.AddScoped<IMedicalCaseRepository, MedicalCaseRepository>();
        services.AddScoped<IPatientInsuranceRepository, PatientInsuranceRepository>();
        services.AddScoped<IOncologyRepository, OncologyRepository>();
        services.AddScoped<IProvidedServiceRepository, ProvidedServiceRepository>();
        services.AddScoped<IClinicalGroupRepository, ClinicalGroupRepository>();

        services.AddScoped<INazNaprCategoryRepository, NazNaprCategoryRepository>();
        services.AddScoped<IDefectsSanksCategoryRepository, DefectsSanksCategoryRepository>();

        services.AddSingleton<IPasswordHasherService, Argon2PasswordHasherService>();
        services.AddSingleton<ITokenGenerationService, TokenGenerationService>();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationMediatrMarker).Assembly));

        return services;
    }

    private static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        
        var connectionString = new ConnectionString();

        configuration.GetSection("ConnectionString").Bind(connectionString);

        services.AddDbContextFactory<SMODbContext>(
            options =>
            {
                options.UseSqlServer(connectionString.SMODB18);
            });

        services.AddDbContextFactory<InogorodDbContext>(
            options =>
            {
                options.UseSqlServer(connectionString.INOGOROD18);

            });

        services.AddAutoMapper(config =>
        {
            config.AddProfile<UserEntityMappingProfile>();
        });

        services.AddScoped<DbContextFactory>();

        return services;
    }

    private static IServiceCollection AddWebServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var jwtSettings = new JwtSettings();
        configuration.GetSection("JwtSettings").Bind(jwtSettings);

        services.AddCors();
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });


        services.AddAutoMapper(config =>
        {
            config.AddProfile<UserRequestMappingProfile>();
        });

        services.AddOptions<JwtSettings>().Bind(configuration.GetSection("JwtSettings"));

        return services;
    }
}