using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Query;
using Patient.Application.Response;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.QueryHandler
{
    public class SelectPatientByIdHandler : IRequestHandler<SelectPatientByid, PatientRequest>
    {
        public PatientRepositry repostiry;
        public IMapper mapper;
        public ILogger<SelectPatientByIdHandler> logger;    
        public SelectPatientByIdHandler(IMapper mapper ,PatientRepositry reposi, ILogger<SelectPatientByIdHandler> logg) 
        
        { 
            this.mapper = mapper;
            this.repostiry = reposi;
            this.logger = logg;
        
        }
        public async Task<PatientRequest> Handle(SelectPatientByid request, CancellationToken cancellationToken)
        {
            logger.LogInformation("the process of selectElemntByid start");
            var patient= await repostiry.GetPatientByid(request.Id);
            if (patient == null)
            {

            }
            logger.LogInformation($"Patient id: {request.Id} tne procees is done");
           return mapper.Map<PatientRequest>(patient);
           
        }
    }
}
