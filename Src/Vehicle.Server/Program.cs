using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Serilog;
using Vehicle.Repository.Extensions;
using Vehicle.Repository.Options;
using Vehicle.Server.Options;
using Vehicle.Server.Services;


public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

        var applicationOptions = builder.Configuration.GetSection(ApplicationOptions.Name).Get<ApplicationOptions>();
        var applicationName = applicationOptions?.ApplicationName!;

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
#if DEBUG
            .WriteTo.Console()
#endif
            .CreateLogger();

        try
        {
            //Log.Information($"Starting the {applicationName} web application...");

            builder.Services.AddLogging();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var repositoryOptions = builder.Configuration.GetSection(RepositoryOptions.Name).Get<RepositoryOptions>();
            builder.Services.AddRepositories(repositoryOptions);
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            builder.Host.UseSerilog();

            // After all AddHttpClient registrations.
            builder.Services.RemoveAll<IHttpMessageHandlerBuilderFilter>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
            return 0;
        }
        catch (Exception ex)
        {
            //Log.Fatal(ex, $"The {applicationName} application start-up failed");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}