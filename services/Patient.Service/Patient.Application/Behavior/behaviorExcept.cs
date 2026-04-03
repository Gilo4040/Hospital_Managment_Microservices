using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Behavior
{
    public class behaviorExcept<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public ILogger<TRequest> Logger;
        public behaviorExcept(ILogger<TRequest> Logg)
        {
            this.Logger = Logg;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception  ex)
            {
                var requestAction = typeof(TRequest).Name;
                Logger.LogInformation($" the exception occur with type {requestAction} and request is {request}");

                throw;
            }

        }
    }
}
