using Doctor.Grpc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Query
{
    public  class SelectNameDocotorById:IRequest<DoctorResponse>
    {
        public int Id { get; set; }
        public SelectNameDocotorById( DoctorRequest doctorRequest)
        {
            Id = doctorRequest.Id;
        }

    }
}
