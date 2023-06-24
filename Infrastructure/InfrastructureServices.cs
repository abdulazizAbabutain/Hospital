using Application.Common.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(option =>
            {
                //option.UseSqlite("Data Source=mydb.db;");
                option.UseSqlServer("Server=.;Database=HospitalAppDb; User Id=sa;Password=123;TrustServerCertificate=True");
                option.LogTo(Console.WriteLine);
            });

            // register service 
            services.AddScoped<IRepositoryManager, RepositoryManager>(); 
            return services;
        }
    }
}
