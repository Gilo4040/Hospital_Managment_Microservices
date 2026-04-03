using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Behivor
{
    public class BehaviorHandleException<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public ILogger<TRequest> _logger; 
        public BehaviorHandleException(ILogger<TRequest> _logg)
        {
            this._logger = _logg;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
               return  await next();
            }
            catch(Exception ex)
            {
                var requestAction = typeof(TRequest).Name;
                _logger.LogInformation($" the exception occur with type {requestAction} and request is {request}");

                throw;
            }
         
        }
    }
}
