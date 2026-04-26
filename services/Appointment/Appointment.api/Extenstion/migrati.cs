
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using static Azure.Core.HttpHeader;

namespace Appoinment.api.Extenstion
{
    public static class migrati
    {
        public static async Task<IHost> MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var masterConnectionString = connectionString
                .Replace("Database=Appointment", "Database=master");

            
            var retries = 10;
            while (retries > 0)
            {
                try
                {
                    using var connection = new SqlConnection(masterConnectionString);
                    await connection.OpenAsync();

                    await connection.ExecuteAsync(@"
                IF DB_ID('Appointment') IS NULL
                CREATE DATABASE Appointment;
                  ");

                    break;
                }
                catch
                {
                    retries--;
                    if (retries == 0) throw;

                    await Task.Delay(3000);
                }
            }

            // 🔗 connect على Appointment
            var dbConnectionString = masterConnectionString
                .Replace("Database=master", "Database=Appointment");

            using var appConnection = new SqlConnection(dbConnectionString);
            await appConnection.OpenAsync();

            // ✅ check table
            var tableExists = await appConnection.QueryFirstOrDefaultAsync<int>(@"
             SELECT COUNT(*) 
            FROM INFORMATION_SCHEMA.TABLES 
              WHERE TABLE_NAME = 'Appointments'
            ");

            if (tableExists == 0)
            {
                // ✅ create table
                 await appConnection.ExecuteAsync(@"
                CREATE TABLE Appointments (
                Id INT IDENTITY PRIMARY KEY,
                PatientId INT,
                DoctorId INT,
                StartTime DATETIME,
                EndTime DATETIME,
                Status INT NOT NULL,
                Notes NVARCHAR(MAX)
                )
               ");

                // ✅ seed data
                await appConnection.ExecuteAsync(@"
                    INSERT INTO Appointments 
                   (PatientId, DoctorId, StartTime, EndTime, Status, Notes)
                   VALUES 
                    (@PatientId, @DoctorId, @StartTime, @EndTime, @Status, @Notes)
                     ",
                new[]
                {
            new {
                PatientId = 1,
                DoctorId = 1,
                StartTime = new DateTime(2026, 4, 18, 10, 0, 0),
                EndTime = new DateTime(2026, 4, 18, 10, 30, 0),
                Status = 1,
                Notes = "Checkup"
            },
            new {
                PatientId = 2,
                DoctorId = 1,
                StartTime = new DateTime(2026, 4, 18, 12, 0, 0),
                EndTime = new DateTime(2026, 4, 18, 12, 30, 0),
                Status = 1,
                Notes = "Follow up"
            },
            new {
                PatientId = 3,
                DoctorId = 2,
                StartTime = new DateTime(2026, 4, 18, 9, 30, 0),
                EndTime = new DateTime(2026, 4, 18, 10, 0, 0),
                Status = 1,
                Notes = "First visit"
            }
                });
            }

            return host;
        }
    
    }  
}
