using MediatR;
using Patient.Application.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Command
{
    public class AddPatientRequest:IRequest<bool>
    {
        public RequestPatient Response { get; set; }
        public AddPatientRequest(RequestPatient Respone)
        { 
           this. Response = Respone;
        
        }
    }
}
