using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Command;
using Patient.Application.Handler.QueryHandler;
using Patient.Core.Entity;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.CommandHandler
{
    public class AddPatientRequestHandler:IRequestHandler<AddPatientRequest,bool>
    {
       public IMapper mapper;
        public PatientRepositry PatientRepositry;
        public ILogger<AddPatientRequestHandler> logger;
        public AddPatientRequestHandler( IMapper mapp , PatientRepositry PatientRep, ILogger<AddPatientRequestHandler> logg)
        {
            mapper = mapp;
            PatientRepositry = PatientRep;
            logger = logg;

        }

        public async Task<bool> Handle(AddPatientRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("the process of add start");
            var result= mapper.Map<patient>(request.Response);
           var resulAdd=  await PatientRepositry.AddPation(result);
            logger.LogInformation("the process of add  is successed");
            return resulAdd;
           

        }
    }
}
