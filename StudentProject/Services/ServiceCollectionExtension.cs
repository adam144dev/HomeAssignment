using Microsoft.Extensions.DependencyInjection;

namespace StudentProject.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IProjectService, ProjectService>();

            return services;
        }
    }
}
