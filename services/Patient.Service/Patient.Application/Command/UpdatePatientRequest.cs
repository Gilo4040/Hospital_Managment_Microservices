using MediatR;
using Patient.Application.Request;
using Patient.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Command
{
    public  class UpdatePatientRequest:IRequest<bool>
    {
        public RequestPatient Patient { get; set; }
        public UpdatePatientRequest(RequestPatient patient)
        {
            this.Patient = patient;
        
        }

    }
}
