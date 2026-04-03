using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Patient.Application.Behavior;
using Patient.Application.Profeil;
using System.Reflection;

namespace Patient.Application.Exetiention
{
    public static  class SetiProgram
    {
        public static IServiceCollection AddExte(this IServiceCollection service )
        {
            service.AddAutoMapper(x => x.AddProfile(new ProfeilPatient()));
             service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaiorValidator<,>));
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(behaviorExcept<,>));
            return service;

        }
    }
}
