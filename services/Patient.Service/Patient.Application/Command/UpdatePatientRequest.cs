using MediatR;
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
        public PatientRequest Patient { get; set; }
        public UpdatePatientRequest(PatientRequest patient)
        {
            this.Patient = patient;
        
        }

    }
}
