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
    public  class SelectListOfDocotorWithCondation:IRequest<List<ResponselistOfDoctors>>
    {
        public List< Expression<Func<doctor.core.entity.Doctor, bool>>> Expression { get; set; }
        public Expression<Func<doctor.core.entity.Doctor,Deparment>> expres {  get; set; }
        public SelectListOfDocotorWithCondation(List<Expression<Func<doctor.core.entity.Doctor, bool>>> Expr, Expression<Func<doctor.core.entity.Doctor, Deparment>> expressi)
        {
            Expression = Expr;
            expres= expressi;
        }
    }
}
