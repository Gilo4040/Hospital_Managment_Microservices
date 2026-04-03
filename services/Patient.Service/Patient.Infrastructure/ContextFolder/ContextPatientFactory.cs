using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.ContextFolder
{
    public class ContextPatientFactory : IDesignTimeDbContextFactory<Contextpatient>
    {
        public Contextpatient CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<Contextpatient>();
         
            var result= option.UseNpgsql("Host = postgres_db; Port = 5432; Database = PatientDB; Username = postgres; Password = 123456");
            return new Contextpatient(result.Options);
        }
    }
}
