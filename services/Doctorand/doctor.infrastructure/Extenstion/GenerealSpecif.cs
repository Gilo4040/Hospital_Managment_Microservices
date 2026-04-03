using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.Extenstion
{
    public static class GenerealSpecif
    {
        public static  IQueryable<T> specification<T>(this IQueryable<T> list , List<Expression<Func<T,bool>>> expressions ) where T : BaseClass
        {
            
            for (int i=0; i<expressions.Count();i++)
            {
               list= list.Where(expressions[i]);

            }
            return list;

        }
    }
}
