using doctor.application.Response;
using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Condition
{
    public  static  class ExtntionCondition
    {
     
        public  static List<Expression<Func<T, bool>>> Express<T,B>(this B baseCl ) where T : BaseClass where B : class
        {
            List<Expression<Func<T, bool>>> expression =new();
            Expression<Func<T, bool>> EndExpression1=x=>true;
             foreach (var propraty  in typeof(B).GetProperties())
            {
                var proValue = propraty.GetValue(baseCl);
                if (proValue == null )
                    continue;

                
                var entityProp = typeof(T).GetProperty(propraty.Name);
                if (entityProp == null)
                    continue;
                //if (entityProp.PropertyType == typeof(string))
                //{

                //    if (proValue.ToString().Length <= 3)
                //    {
                //        var Par = Expression.Parameter(typeof(T), "x");

                //        var propertAccess = Expression.Property(Par, entityProp);
                //        // x.departmanId

                //        var constan = Expression.Constant(proValue, entityProp.PropertyType); // typeof int , 1
                //        var equa = Expression.Equal(propertAccess, constan);

                //        var lambd = Expression.Lambda<Func<T, bool>>(equa, Par);

                //        expression.Add(lambd);





                //    }


                //}
        
                var Para = Expression.Parameter(typeof(T),"x");
            
                var propertyAccess = Expression.Property(Para, entityProp);
                // x.departmanId

                var constant = Expression.Constant(proValue,entityProp.PropertyType); // typeof int , 1
                var equal = Expression.Equal(propertyAccess, constant);

                var lambda = Expression.Lambda<Func<T, bool>>(equal, Para);

                expression.Add(lambda);

             

              


            }
           
            return expression;

          
           

          
             



        }
      
    }
}
