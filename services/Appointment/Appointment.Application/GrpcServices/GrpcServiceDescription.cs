using Patient.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.GrpcServices
{
    public  class GrpcServiceDescription
    {
        public PatientService.PatientServiceClient patientServiceCleint { get; set; } 
    }
}
