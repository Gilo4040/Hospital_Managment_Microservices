using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace doctor.core.repositry
{
     public  interface Genericrepositry<T ,B > where T : BaseClass where B :BaseClass
     {
        public Task<IEnumerable<T>> ListOfELementWithCondation(List<Expression<Func<T,bool>>>expression, Expression<Func<T, B>> exp);
        public Task<IEnumerable<T>> ListOfELement(Expression<Func<T, B>> expression);
        public Task<bool> AddElement(T t);
        public Task<bool> DeleteElement(int id );
        public Task<T> SearchByName(string name);
        public Task<T> SelectElementById(int id);
        public Task<T> UpdataElement(T element);
    

     }
}
