using RestSharp;
using StudentsMVC.Interfaces;
using StudentsMVC.Repositories;
using StudentsMVC.Services;

namespace StudentsMVC.Extensions;

public static class ServiceExtension
{
    // Function AddServices in configuration program
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Add RestClient
        services.AddSingleton<IRestClient>(_ => new RestClient());

        // Add StudentService
        services.AddScoped<IStudentService, StudentService>();

        // ADd StudentRepository
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}