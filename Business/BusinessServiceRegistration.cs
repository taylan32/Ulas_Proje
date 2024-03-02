using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // her servis için eklenecek
            services.AddScoped<ICategoryService, CategoryService>();

            // business rules eklenecek
            services.AddScoped<CategoryBusinessRules>();

            return services;
        }
    }
}
