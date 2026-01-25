using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleCrud.Contracts.DTO;
using SampleTwoCRUD.EntityFramework.Data;

namespace SampleTwoCRUD.Injections;

public static class ServiceInjection
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration config)
    {
        string? connString = config.GetSection("AppSettings:DBConnectionString").Value;
        if (string.IsNullOrEmpty(connString))
            throw new InvalidOperationException("Database connection string is not configured. Please setup your Database.");

        services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connString));
        return services;
    }

    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services)
    {
        services.AddOptions<AppSettings>()
       .BindConfiguration(nameof(AppSettings))
       .ValidateDataAnnotations()
       .Validate(settings =>
       {
           if (settings.DBConnectionString.Length is 0 )
               return false;

           return true;
       })
       .ValidateOnStart();

        //services.AddOptions<AppSettings>()
        //    .Configure<IConfiguration>((settings, configuration) =>
        //    {
        //        configuration.GetSection("AppSettings").Bind(settings);
        //    });

        return services;
    }
}
