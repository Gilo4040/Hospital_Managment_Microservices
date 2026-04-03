using doctor.application.Response;
using doctor.core.entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Query
{
    public  class ListOfDoctorsResponse:IRequest<List<ResponselistOfDoctors>>
    {
        public Expression<Func<Doctor, Deparment>> exp;
        public ListOfDoctorsResponse(Expression<Func<Doctor,Deparment >> expression)
        {
            exp = expression;

        }

    }
}
