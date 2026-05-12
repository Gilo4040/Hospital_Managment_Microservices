using AutoMapper;
using MediatR;
using Patient.Application.Query;
using Patient.Application.Response;
using Patient.Core.Entity;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.QueryHandler
{
    public class SelectListOfPatientHandler : IRequestHandler<SelectListOfPatient, List<Response.PatientRequest>>
    {
         private readonly IMapper Map;
        public Core.Repositry.PatientRepositry patientReposit;
       public SelectListOfPatientHandler(IMapper Map,Core.Repositry.PatientRepositry patient )
        
        { 
            this.Map = Map;
            this.patientReposit = patient;

        
        }

        public async Task<List<Response.PatientRequest>> Handle(SelectListOfPatient request, CancellationToken cancellationToken)
        {
            var patients = await patientReposit.ListOfPatientWithCondation(request.Expression);
            var result = Map.Map<List<PatientRequest>>(patients);
            return result;



        }
    }
    
}
