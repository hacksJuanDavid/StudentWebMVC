using StudentsMVC.Interfaces;
using StudentsMVC.Repositories;
using StudentsMVC.Services;

namespace StudentsMVC.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}