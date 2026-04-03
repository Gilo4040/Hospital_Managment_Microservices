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
        public PatientResponse Patient { get; set; }
        public UpdatePatientRequest(PatientResponse patient)
        {
            this.Patient = patient;
        
        }

    }
}
