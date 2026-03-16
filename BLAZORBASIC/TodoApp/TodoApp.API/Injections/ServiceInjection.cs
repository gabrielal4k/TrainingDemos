using Microsoft.EntityFrameworkCore;
using Todo.Contracts.DTO;
using Todo.Contracts.Interface.Data;
using Todo.Contracts.Interface.Service;
using Todo.DA;
using Todo.DA.Context.Data;
using Todo.Service.Module;

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

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEvents, Events>();
        return services;
    }

    public static IServiceCollection AddSwaggerOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

}
