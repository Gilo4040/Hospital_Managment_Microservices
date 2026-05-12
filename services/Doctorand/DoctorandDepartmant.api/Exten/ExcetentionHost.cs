using doctor.application.Response;
using doctor.core.entity;
using doctor.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoctorandDepartmant.api.Exctention
{
    public static  class ExcetentionHost
    {
        public static async Task<IHost> migrateDataBase<contextgeneric>(this IHost server) where contextgeneric : DbContext
        {
            using var scope = server.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<contextgeneric>();

            for (int i = 0; i < 15; i++)
            {
                try
                {
                    await db.Database.MigrateAsync();
                    await Seed(db);
                    await SeedDocotr(db);
                    Console.WriteLine("DB Ready");
                    return server;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Waiting DB... " + ex.Message);
                    await Task.Delay(3000);
                }
            }

            Console.WriteLine("Migration skipped");
            return server;

        }
       
            public static async Task Seed(DbContext context)
            {
                if ( ! await context.Set<Deparment>().AnyAsync())
                {
                    var departmants = new List<Deparment> 
                    {
            
                       new Deparment {  Name = "Cardiology" },
                           new Deparment {  Name = "Neurology" },
                     new Deparment {  Name = "Orthopedics" },
                        new Deparment { Name = "Pediatrics" },
                       new Deparment { Name = "Dermatology" }
                   };
                  
                    
                    await context.Set<Deparment>().AddRangeAsync(departmants);
                    await context.SaveChangesAsync();
                }
            }
        
       
        
            public static async Task SeedDocotr(DbContext context)
            {
                if (!await context.Set<doctor.core.entity.Doctor>().AnyAsync())
                {
                    var doctors = new List<doctor.core.entity.Doctor>
                    {
                new doctor.core.entity.Doctor {  Name = "Dr. Ahmed Ali", age = 45, Description = "Cardiologist", DepartmantID = 1,Phone="01001320699" },
                new doctor.core.entity.Doctor  { Name = "Dr. Sara Mohamed", age = 38, Description = "Neurologist", DepartmantID = 2,Phone="01009904995" },
                new doctor.core.entity.Doctor {  Name = "Dr. Hassan Saleh", age = 50, Description = "Orthopedic Surgeon", DepartmantID = 3, Phone="01091656503" },
                new doctor.core.entity.Doctor {  Name = "Dr. Nadia Mostafa", age = 42, Description = "Pediatrician", DepartmantID = 1 ,Phone="01030400450"},
                new doctor.core.entity.Doctor {  Name = "Dr. Omar Fathy", age = 37, Description = "Dermatologist", DepartmantID = 2,Phone="01001320699"},
                new doctor.core.entity.Doctor { Name = "Dr. Laila Mahmoud", age = 41, Description = "Gynecologist", DepartmantID = 3 ,Phone = "01095103018"},
                new doctor.core.entity.Doctor {  Name = "Dr. Khaled Hossam", age = 55, Description = "Cardiothoracic Surgeon", DepartmantID = 1,Phone="0040004" },
                new doctor.core.entity.Doctor {  Name = "Dr. Mona Samir", age = 35, Description = "Radiologist", DepartmantID = 2 ,Phone="00595958"},
                    };

                    await context.Set<doctor.core.entity.Doctor>().AddRangeAsync(doctors);
                    await context.SaveChangesAsync();
                }
            }
        
    }
}
