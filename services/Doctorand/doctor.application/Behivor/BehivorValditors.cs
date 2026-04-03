
using doctor.application.exception;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Behivor
{
    public class BehivorValditors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public IEnumerable<IValidator<TRequest>> validators;
        public BehivorValditors(IEnumerable<IValidator<TRequest>> Validator)
        {
            this.validators = Validator;

        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var elemnt =  new ValidationContext<TRequest>(request);
            if(validators.Any())
            {
               var result=  await Task.WhenAll( validators.Select(x =>   x.ValidateAsync(elemnt, cancellationToken)));


                var ElemntError = result.SelectMany(x => x.Errors).Where(x=>x!=null);
                if(ElemntError.Any())
                   throw new ExceptionValdiator(ElemntError);
            }
            return await next();
           
            
        }
    }
}
