using Patient.Application.Request;
using Patient.Application.Response;
using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Exetiention
{
    public static  class SpecificationcPatient
    {
       
        public static List<Expression<Func<patient,bool>>> expression(this RequestPatient patient)
        {
              List<Expression<Func<patient, bool>>> Expression = new();
           if (patient == null)
            {


                Expression.Add(x=>true);
            }

           else
           { 
                if (patient.Id.HasValue)
                {
                    Expression.Add(x=>x.Id==patient.Id.Value);


                }
                if (patient.Name!=null)
                {   
                    Expression.Add(x=>x.Name==patient.Name);

                }
                if (patient.age.HasValue)
                {

                    Expression.Add(x=>x.age==patient.age.Value);
                }
                if (patient.MedicalHistory!=null)
                {
                    Expression.Add(x=>x.MedicalHistory==patient.MedicalHistory);

                }

           }
           return Expression;

        }
    }
}
