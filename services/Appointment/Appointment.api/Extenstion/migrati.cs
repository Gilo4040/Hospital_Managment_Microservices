using Appoinment.Core.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using static Azure.Core.HttpHeader;

namespace Appoinment.api.Extenstion
{
    public static  class migrati
    {
        public static async Task<IHost> migrateDataBase(this IHost server)
        {
            using var scope = server.Services.CreateScope();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
          

            using var connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));


            var exists = await connection.QueryFirstOrDefaultAsync<int>(
              "SELECT COUNT(1) FROM Appointments");

            if (exists == 0)
            {
                var sql = @"
               CREATE TABLE Appointments (
                Id INT IDENTITY PRIMARY KEY,
                PatientId INT,
                DoctorId INT,
                StartTime DATETIME,
                EndTime DATETIME,
                Status INT NOT NULL,
                Notes NVARCHAR(MAX)
                )";
            }
            var sql2 = @"
             INSERT INTO Appointments 
             (PatientId, DoctorId, StartTime, EndTime, Status, Notes)
             VALUES 
             (@PatientId, @DoctorId, @StartTime, @EndTime, @Status, @Notes)";
        await connection.ExecuteAsync(sql2, new[]
        {
        new
        {
            PatientId = 1,
            DoctorId = 1,
            StartTime = new DateTime(2026, 4, 18, 10, 0, 0),
            EndTime = new DateTime(2026, 4, 18, 10, 30, 0),
            Status = AppointmentStatus.Confirmed,
            Notes = "Checkup"
        },
        new
        {
            PatientId = 2,
            DoctorId = 1,
            StartTime = new DateTime(2026, 4, 18, 12, 0, 0),
            EndTime = new DateTime(2026, 4, 18, 12, 30, 0),
            Status = AppointmentStatus.Confirmed,
            Notes = "Follow up"
        },
        new
        {
            PatientId = 3,
            DoctorId = 2,
            StartTime = new DateTime(2026, 4, 18, 9, 30, 0),
            EndTime = new DateTime(2026, 4, 18, 10, 0, 0),
            Status = AppointmentStatus.Confirmed,
            Notes = "First visit"
        }
        });





            await connection.OpenAsync();

            return server;
        }
    }
}
