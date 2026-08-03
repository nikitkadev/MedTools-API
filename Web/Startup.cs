using Web.Registration.DI;
using Web.Registration.Endpoints;

using Serilog;

namespace Web;

public class Startup
{
    public static async Task Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        var builder = WebApplication.CreateBuilder();

        builder.Services.RegistrateAppServices(builder.Configuration);
        builder.Host.UseSerilog();

        var app = builder.Build();

        app.UseDeveloperExceptionPage();
        app.UseCors(
            policy =>
            {
                policy.AllowAnyOrigin(); //Затычка для dev-среды
                policy.AllowAnyMethod(); //Затычка для dev-среды
                policy.AllowAnyHeader(); //Затычка для dev-среды
            });

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        EndpointsProvider.RegisterAppEndpoints(app.MapGroup("/api"));

        await app.RunAsync();
    }
}