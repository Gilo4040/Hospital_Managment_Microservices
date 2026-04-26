using Doctor.Grpc;
using Patient.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.GrpcServices
{
    public  class GrpcPatientServiceDescription
    {
        private readonly PatientService.PatientServiceClient patientServiceCleint;
        public GrpcPatientServiceDescription(PatientService.PatientServiceClient patient)
        {
            patientServiceCleint=patient;
        }
        public async Task<PatientRespons> GetPatient(int id )
        {
          PatientRequest patient =   new  PatientRequest { Id=id};
            return await patientServiceCleint.GetPatientByIdAsync(patient);
        }
      
    }
}
