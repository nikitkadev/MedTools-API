using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Core.Interfaces.Auth;
using Core.Interfaces.Repositories.Users;
using Core.Interfaces.Repositories.RControl;

using Application;

using Infrastructure.Mapping;
using Infrastructure.Options;
using Infrastructure.Database;
using Infrastructure.Database.Factories;
using Infrastructure.Implementations.Services;
using Infrastructure.Implementations.Repositories.Users;
using Infrastructure.Implementations.Repositories.RControl;

using Web.Mapping;
using Web.Options;

namespace Web.Registration.DI;

public static class DependencyInjectionRegistrator
{
    public static IServiceCollection RegisterAppServices(
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
        services.AddScoped<IClinicalGroupRepository, ClinicalGroupRepository>();
        services.AddScoped<ICompletedCaseRepository, CompletedCaseRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<ILookupsRepository, LookupsRepository>();
        services.AddScoped<IMedicalCaseRepository, MedicalCaseRepository>();
        services.AddScoped<IMedicationRepository, MedicationRepository>();
        services.AddScoped<IOncologyCaseRepository, OncologyCaseRepository>();
        services.AddScoped<IOncologyServiceRepository, OncologyServiceRepository>();
        services.AddScoped<IProvidedServiceRepository, ProvidedServiceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
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