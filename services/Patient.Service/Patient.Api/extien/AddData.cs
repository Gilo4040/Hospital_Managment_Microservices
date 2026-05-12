using Microsoft.EntityFrameworkCore;
using Patient.Core.Entity;

namespace Patient.Api.extien
{
    public static class  AddData
    {
        
         public static async Task<IHost> MigrateDatabase<TContext>(this IHost server)
where TContext : DbContext
        {
            using var scope = server.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TContext>();

         
  
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    Console.WriteLine("Trying DB...");
                    await db.Database.MigrateAsync();
                    Console.WriteLine("Migration Done");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Waiting DB... " + ex.Message);
                    await Task.Delay(3000);
                }
            }

         
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    await Seed(db);
                    Console.WriteLine("Seed Done ✅");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Seed Failed ❌ retrying... " + ex.Message);
                    await Task.Delay(3000);
                }
            }

            return server;
        }
        private async static Task Seed(DbContext Db)
        {
            if (!await Db.Set<patient>().AnyAsync())
            {
                var patients = new List<patient>
                                              {
                new patient
                {

                  Name = "Ahmed Ali",
                
                 age = 41,
                    MedicalHistory = "Diabetes"
                },
                  new patient
                  {
                      
                     Name = "Mona Hassan",
                      
                            age = 35,
                         MedicalHistory = "Hypertension"
                   },
                 new patient
                 {

                     Name = "Khaled Samir",
                     
                         age = 24,
                        MedicalHistory = null
                 },
                  new patient
                  {

                     Name = "Sara Ahmed",
                   
                     age = 48,
                   MedicalHistory = "Asthma"
                  },
                   new patient
                   {

                       Name = "Omar Mahmoud",
                    
                        age= 16,
                       MedicalHistory = "Allergy"
                   }

                            };
                await Db.Set<patient>().AddRangeAsync(patients);
                await Db.SaveChangesAsync();    

            }
        }
    }
}

