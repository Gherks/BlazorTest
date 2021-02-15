using Blazor.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<EmployeeRepositoryInterface, EmployeeRepository>();
            return services;
        }
    }
}
