using doctor.application.mapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using doctor.application.Behivor;

namespace doctor.application.Extenstion2
{
    public  static  class Extenstionclass2                                
    {
        public static IServiceCollection ServiceColl(this IServiceCollection services )
        {
           services.AddAutoMapper(x=>x.AddProfile( new DocotorProfeile()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(BehivorValditors<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorHandleException<,>));
            return services;

        }
        
    }
}
