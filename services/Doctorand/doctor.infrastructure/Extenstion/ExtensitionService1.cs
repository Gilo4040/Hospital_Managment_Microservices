using doctor.core.repositry;
using doctor.infrastructure.Context;
using doctor.infrastructure.ImplementRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.Extenstion
{
    public static class ExtensitionService1
    {
        public  static IServiceCollection serviceCollection( this IServiceCollection services , IConfiguration Confi)
        {
            services.AddDbContext<ContextEntity>(options => options.UseSqlServer(Confi.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            }));
            services.AddScoped(typeof(Genericrepositry<,>),typeof(implementGeneric<,>) );
            services.AddScoped<IrepositryDoctor, ImplementDoctor>();
            services.AddScoped<IrepositryDepartmant,ImplementDepartment>();
            return services;

        }
        

        
    }
}
