using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Command;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.CommandHandler
{
    public class DeletePatientByIdHandler : IRequestHandler<DeletePatientById, bool>
    {
       // public IMapper mapper;
        public PatientRepositry Patient;
        public ILogger<DeletePatientByIdHandler> logger;
        public DeletePatientByIdHandler(IMapper mapp , PatientRepositry patient, ILogger<DeletePatientByIdHandler> log)
        {
          //  this.mapper = mapp;
            this.Patient = patient;
            this.logger = log;
        }
        public async Task<bool> Handle(DeletePatientById request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"the process of Delete start  {request.Id}");
            var result= await Patient.DeletePatient(request.Id);
            logger.LogInformation("the process of Delete Succed");
             return result;
             
        }
    }
}
