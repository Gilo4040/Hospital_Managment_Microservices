using MediatR;
using Patient.Application.Response;
using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Query
{
    public  class SelectPatientByid:IRequest<PatientResponse>
    {
        public int Id { get; set; }
        public SelectPatientByid( int id )
        {
            Id = id;

        }
    }
}
