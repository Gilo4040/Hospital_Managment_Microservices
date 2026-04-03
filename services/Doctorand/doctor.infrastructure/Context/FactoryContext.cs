using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.Context
{
    public class FactoryContext : IDesignTimeDbContextFactory<ContextEntity>
    {
        public ContextEntity CreateDbContext(string[] args)
        {
            

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var Option = new DbContextOptionsBuilder<ContextEntity>();
           var optionConnection=   Option.UseSqlServer("Server=localhost;Database=DoctorAndDepartmant;User sa;Password=StrongPassword123!;TrustServerCertificate=True;");
            return new ContextEntity(Option.Options);

        }
    }
}
