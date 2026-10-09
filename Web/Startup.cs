using System.Text.Json.Serialization;

using Serilog;

using Web.Registration.DI;
using Web.Registration.Endpoints;

namespace Web;

public class Startup
{
    public static async Task Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        var builder = WebApplication.CreateBuilder();

        builder.Services.RegisterAppServices(builder.Configuration);
        builder.Services.AddWindowsService(options =>
        {
            options.ServiceName = "MedTools API";
        });
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Host.UseSerilog();
        builder.WebHost.ConfigureKestrel(
            options =>
            {
                options.ListenAnyIP(8005);
                options.AddServerHeader = false;
            });

        var app = builder.Build();

        app.UseDeveloperExceptionPage();
        
        app.UseCors(
            policy =>
            {
                policy.AllowAnyOrigin(); // Затычка для пре-релиза
                policy.AllowAnyMethod(); 
                policy.AllowAnyHeader();
                
            });

        
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        EndpointsProvider.RegisterAppEndpoints(app.MapGroup("/api"));

        await app.RunAsync();
    }
}