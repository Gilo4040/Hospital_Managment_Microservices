using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Patient.Core.Entity;
using Patient.Core.Repositry;
using Patient.Infrastructure.ContextFolder;
using Patient.Infrastructure.Exetientation2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.ImplementRepositry
{
    public class Implamentpatient : PatientRepositry
    {
        public Contextpatient context;
        public Implamentpatient(Contextpatient co)
        { 
            this.context = co;
        
        }
        public async Task<bool> AddPation(patient P)
        {
             var result= await context.patients.AddAsync(P);
        
             await context.SaveChangesAsync();
           
             return true;

           
        }

        public async Task<bool> DeletePatient(int id)
        {
            var result = await GetPatientByid(id);
             context.patients.Remove(result);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<patient> GetPatientByid(int id)
        {
            var result = await context.patients.FindAsync(id);
            return result;


           

        }

        public async Task<List<patient>> ListofPatients()
        {
            return await context.patients.ToListAsync();
        }

        public async Task<List<patient>> ListOfPatientWithCondation(List<Expression<Func<patient, bool>>> expression)
        {

            var result = await context.patients.Specific(expression).ToListAsync();
            return result;
            
        }

        public async Task<bool> UpdatePation(patient Pa)
        {
             context.patients.Update(Pa);
            await context.SaveChangesAsync();
            return true;

        }
    }
}
