using Microsoft.EntityFrameworkCore;
using Todo.Contracts.DTO;
using Todo.DA;

namespace TodoApp.API.Injections;

public static class ServiceInjection
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection service, IConfiguration config)
    {

        string? connString = config.GetSection("AppSettings:DBConnectionString").Value;
        if (string.IsNullOrEmpty(connString))
            throw new InvalidOperationException("Database connection string is not configured. Please setup your Database.");


        service.AddDbContext<TodoDBContext>(options =>
        {
            options.UseSqlServer(connString);
        });
        return service;
    }
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services)
    {
        services.AddOptions<AppSettings>()
       .BindConfiguration(nameof(AppSettings))
       .ValidateDataAnnotations()
       .Validate(settings =>
       {
           if (settings.DBConnectionString.Length is 0)
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
