using Microsoft.EntityFrameworkCore;
using ShortURL.BLL.Interfaces;
using ShortURL.BLL.Services;
using ShortURL.DAL;
using ShortURL.DAL.Interfaces;
using ShortURL.DAL.Models;
using ShortURL.DAL.Repositories;

namespace ShortURL.Api.Infrastructure
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            //BL
            services.AddTransient<IURLService, URLService>();
            services.AddTransient<IUserService, UserService>();

            //DAL
            services.AddTransient<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();
            services.AddTransient<IGenericRepository<URLEntity>, GenericRepository<URLEntity>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = "Server = (localdb)\\MSSQLLocalDB;Initial Catalog=ShortURL1;Integrated Security=True";
            return services.AddDbContext<DataAccsess>(options => options.UseSqlServer(connection));
        }

    }
}
