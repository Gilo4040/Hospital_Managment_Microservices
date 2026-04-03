using MediatR;
using Patient.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Command
{
    public class AddPatientRequest:IRequest<bool>
    {
        public PatientResponse Response { get; set; }
        public AddPatientRequest(PatientResponse Respone)
        { 
           this. Response = Respone;
        
        }
    }
}
