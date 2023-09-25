using RestSharp;
using StudentsMVC.Services;

namespace StudentsMVC.Extensions;

public static class ServiceExtension
{
    // Function AddServices in configuration program
    public static IServiceCollection AddServices(this IServiceCollection services)
    {   
        // Add RestClient
        services.AddScoped<RestClient>();

        // Add StudentService
        services.AddScoped<IStudentService, StudentService>();

        return services;
    }
}