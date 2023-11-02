using BulkinaAnnaKT_31_20.Interfaces.StudentsInterfaces;
using static BulkinaAnnaKT_31_20.Interfaces.StudentsInterfaces.IStudentService;

namespace BulkinaAnnaKT_31_20.ServiceExtenstions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
