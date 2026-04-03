using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.Exetientation2
{
     public static  class Specification
    {
        public static IQueryable<patient> Specific(this IQueryable<patient> patients,List<Expression <Func<patient, bool>>> expressions)
        {
            for (var i = 0; i < expressions.Count(); i++) 
            {

                 patients=patients.Where(expressions[i]);
            
            
            
            
            
            
            
            }
            return patients;

        }

    }
}
