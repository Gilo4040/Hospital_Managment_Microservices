using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Exeption;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Behavior
{
    public class BehaiorValidator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
       public IEnumerable<IValidator<TRequest>> validators;
        
        public BehaiorValidator(IEnumerable<IValidator<TRequest>> validators )
        {
            this.validators = validators;
           

        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = new ValidationContext<TRequest>(request);

            if (validators.Any())
            {
                var validator = await Task.WhenAll(validators.Select(x => x.ValidateAsync(result, cancellationToken)));
                if (validator != null)
                {
                    throw new ExceptionValidator(validator.SelectMany(x => x.Errors).Where(x => x != null));
                }

            }
          
         
            return await next();
        }
    }
}
