using Doctor.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.GrpcServices
{
    public  class GrpcDocotrServiceDescription
    {
       private readonly DoctorService.DoctorServiceClient serviceClient;
        public GrpcDocotrServiceDescription(DoctorService.DoctorServiceClient service)
        {
            serviceClient = service;
        }
        public async Task<DoctorResponse> DoctorDescription(int id )
        {
            DoctorRequest request = new DoctorRequest { Id=id };

            return await serviceClient.GetDoctorByIdAsync(request);

        }
    }
}
