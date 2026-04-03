using doctor.core.entity;
using doctor.core.repositry;
using doctor.infrastructure.Context;
using doctor.infrastructure.Extenstion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.ImplementRepos
{
    public class implementGeneric<T,B> : Genericrepositry<T,B> where T : BaseClass where B :BaseClass
    {
         private ContextEntity _dbContext;
        public implementGeneric(ContextEntity Db) { _dbContext = Db; }
      
        public async  Task<bool> DeleteElement(int id)
        {
            var result = await  SelectElementById(id);
            if (result == null)
            {
                return false;
            }
              _dbContext.Remove(result);
             await _dbContext.SaveChangesAsync();
            
            return true;
          
        }

      

        public  async Task<IEnumerable<T>> ListOfELement(Expression<Func<T, B>> expression)
        {
            var list = await _dbContext.Set<T>().Include(expression).ToListAsync();
                
            return list;
        }

        

        public  async Task<T> SearchByName(string name)
        {
            var result= await _dbContext.Set<T>().FindAsync(name);
            if (result == null) { }
            return result;
            
        }

        public  async Task<T> SelectElementById(int id)
        {
           var result=  await _dbContext.FindAsync<T>(id);
            return result;
        }

        public async Task<T> UpdataElement(T element)
        {

            var result = await _dbContext.AddAsync(element);
            await _dbContext.SaveChangesAsync();
            return element;
             
            
           

          

           
                                
         }

        public async Task<IEnumerable<T>> ListOfELementWithCondation(List<Expression<Func<T, bool>>> express, Expression<Func<T, B>> exp)
        {
            var list = await _dbContext.Set<T>().Include(exp).specification<T>(express)
                .ToListAsync();
            return list;
        }

        public async Task<bool> AddElement(T t)
        {

             await _dbContext.Set<T>().AddAsync(t);
            return true;


        }
    }
    


       
}
