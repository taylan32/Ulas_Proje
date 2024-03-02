using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            // tüm repository ler için eklenmesi gerekiyor.
            // scope içerisine singleton olarak ekler
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            return services;
        }
    }
}
