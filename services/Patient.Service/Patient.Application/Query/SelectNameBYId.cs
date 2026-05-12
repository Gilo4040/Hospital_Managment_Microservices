using MediatR;
using Patient.Application.Response;
using Patient.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Query
{
    public  class SelectNameBYId:IRequest<PatientRespons>
    {
        public int id { get; set; }
        public SelectNameBYId(Grpc.PatientRequest patien)
        {
           id =patien.Id;

        }
    }
}
