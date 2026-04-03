using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Patient.Core.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Reflection;

namespace Patient.Core.Repositry
{
    public  interface  PatientRepositry
    {
        public Task<bool> AddPation(patient P);
        public Task<bool> UpdatePation(patient Pa);
        public Task<patient> GetPatientByid(int id);
        public Task<List<patient>> ListOfPatientWithCondation(List<Expression<Func<patient,bool>>> expression);
        public Task<List<patient>> ListofPatients();
        public Task<bool> DeletePatient(int id);
        
    }
}
