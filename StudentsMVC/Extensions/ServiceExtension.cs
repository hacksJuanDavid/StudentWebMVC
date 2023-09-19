using System.Configuration;
using RestSharp;
using StudentsMVC.Interfaces;
using StudentsMVC.Repositories;
using StudentsMVC.Services;
using StudentsMVC.Settings;

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

        // ADd StudentRepository
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}