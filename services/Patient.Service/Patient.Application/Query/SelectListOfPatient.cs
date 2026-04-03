using MediatR;
using Patient.Application.Response;
using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Query
{
    public class SelectListOfPatient :IRequest<List<PatientResponse>>
    {
        public List< Expression<Func<patient,bool>>> Expression;
        public SelectListOfPatient(List<Expression<Func<patient, bool>>> Expres )
        {
            Expression = Expres;

        }
    }
}
