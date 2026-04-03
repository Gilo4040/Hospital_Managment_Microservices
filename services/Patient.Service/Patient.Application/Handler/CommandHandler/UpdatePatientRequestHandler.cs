using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Command;
using Patient.Application.Response;
using Patient.Core.Entity;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.CommandHandler
{
    public class UpdatePatientRequestHandler:IRequestHandler<UpdatePatientRequest,bool>
    {
        public IMapper Mapper;
        public PatientRepositry patient;
        ILogger<UpdatePatientRequestHandler> logger;
        public UpdatePatientRequestHandler(IMapper map, PatientRepositry patient, ILogger<UpdatePatientRequestHandler> Logg)
        {
            Mapper = map;
            this.patient = patient;
            logger = Logg;

        }

        public async Task<bool> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("the process of update start");

            var elemnt =  Mapper.Map<patient>(request.Patient);
            var resultUpdata= await patient.UpdatePation(elemnt);
            logger.LogInformation("the process of Update succeed");
            return resultUpdata;
        }
    }
}
