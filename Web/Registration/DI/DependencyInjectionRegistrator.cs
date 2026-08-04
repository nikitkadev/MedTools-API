using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Core.Interfaces.Auth;
using Core.Interfaces.Repositories.Filters;
using Core.Interfaces.Repositories.MainField;
using Core.Interfaces.Repositories.Users;
using Core.Interfaces.Repositories.Categories;

using Application;

using Infrastructure.Mapping;
using Infrastructure.Options;
using Infrastructure.Services;
using Infrastructure.Database;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Filters;
using Infrastructure.Repositories.Categories;

using Web.Mapping;
using Web.Options;



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
        services.AddScoped<IInvoiceQueryRepository, InvoiceQueryRepository>();
        services.AddScoped<IBillingPeriodRepository, BillingPeriodRepository>();
        services.AddScoped<IMedicalOrganizationRepository, MedicalOrganizationRepository>();
        services.AddScoped<IInvoiceSummaryRepository, InvoiceSummaryRepository>();
        services.AddScoped<IFinishedCasesRepository, FinishedCasesRepository>();
        services.AddScoped<ICasesRepository, CasesRepository>();
        services.AddScoped<IPatientSmoCategoryRepository, PatientSmoCategoryRepository>();
        services.AddScoped<ICasesCategoryRepository, CasesCategoryRepository>();
        services.AddScoped<IOncologyCategoryRepository, OncologyCategoryRepository>();
        services.AddScoped<IProvidedServicesCategoryRepository, ProvidedServicesCategoryRepository>();
        services.AddScoped<IKsgVmpCategoryRepository, KsgVmpCategoryRepository>();
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