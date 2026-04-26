using Microsoft.EntityFrameworkCore;
using Patient.Core.Entity;

namespace Patient.Api.extien
{
    public static class  AddData
    {
        public static async Task<IHost> migrateDataBase<contextgeneric>(this IHost server) where contextgeneric : DbContext
        {
            using (var scope = server.Services.CreateScope())
            {
              
                var db = scope.ServiceProvider.GetRequiredService<contextgeneric>();

                for (int i = 0; i < 15; i++)
                {
                    try
                    {
                        await db.Database.MigrateAsync();
                        await Seed(db);
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
           

        }
        private async static Task Seed(DbContext Db)
        {
            if (!Db.Set<patient>().Any())
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
                       Id = 2,
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

