using MediatR;
using Patient.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Query
{
    public  class ListOfPatiens:IRequest<List<PatientResponse>>
    {
    }
}
