using Appointment.Core.Entity;
using Appoinment.Core.Repositry;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Appoinment.Infrastrucure.ImplementRepositry
{
    public class ImplementAppointmentInterface : AppointmentRepositry
    {
        private readonly IConfiguration configuration;
        public ImplementAppointmentInterface(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public async Task<bool> AddAppoinment(Appointment.Core.Entity.Appointment appointment)
        {
            using var Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            var sql = @"
                    INSERT INTO Appointments 
                      (PatientId, DoctorId, StartTime, EndTime, Status, Notes)
                   VALUES (@PatientId, @DoctorId, @StartTime, @EndTime, @Status, @Notes);
                     SELECT CAST(SCOPE_IDENTITY() as int);"
            ;
            appointment.EndTime = appointment.StartTime.AddMinutes(30);
            int num =   await Connection.ExecuteScalarAsync<int>(sql, appointment);
            if (num > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Appointment.Core.Entity.Appointment>> appoinments(DateTime date)
        {
            using var Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            var sql = @"
             SELECT * FROM Appointments
            WHERE StartTime >= @StartDate
           AND StartTime < @EndDate";

            var startDate = date.Date;
            var endDate = startDate.AddDays(1);

            var result = await Connection.QueryAsync<Appointment.Core.Entity.Appointment>(sql, new
            {
                StartDate = startDate,
                EndDate = endDate
            });
            return result.ToList();
            
        }

        public async  Task<bool> CancelAppoinment(int Id,DateTime? date)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            var sql = @"
                DELETE FROM Appointments 
                   WHERE PatientId = @PatientId 
                    AND StartTime = @StartTime";

           var rows=  await connection.ExecuteAsync(sql, new
            {
                PatientId = Id,
                StartTime = date
            });

            return rows > 0;
        }

        public async Task<List<(DateTime Start, DateTime End)>> GetDoctorAvailable(int doctorId, DateTime date)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            var startDate = date.Date;
            var endDate = startDate.AddDays(1);
            var sql =  @"
                 SELECT *
                FROM Appointments
               WHERE StartTime >= @StartDate
              AND StartTime < @EndDate;
             AND Status IN ('1', '2')";

            var booked = (await connection.QueryAsync<Appointment.Core.Entity.Appointment>(sql, new
            {
                DoctorId = doctorId,
                StartDate = startDate,
                EndDate = endDate

            })).ToList();

       
            var slots = new List<(DateTime Start, DateTime End)>();
            var start = date.Date.AddHours(9);
            var end = date.Date.AddHours(17);

            while (start < end)
            {
                slots.Add((start, start.AddMinutes(30)));
                start = start.AddMinutes(30);
            }

           
            var available = slots.Where(slot =>
                !booked.Any(b =>
                    b.StartTime < slot.End &&
                    b.EndTime > slot.Start
                )
            ).ToList();

            return available;
        }

        public async Task<List<Appointment.Core.Entity.Appointment>> GetDoctorAppointments(int doctorId,DateTime? date)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            DateTime dateTime;
            if (date.HasValue == false)
            {
                dateTime = DateTime.Now;
            }
            else
            {
                dateTime = date.Value.Date;
            }
            var endDate = dateTime.AddDays(1);
            var sql = @"
              SELECT *
             FROM Appointments
            WHERE DoctorId = @DoctorId
             AND Status != @Status
             AND StartTime >= @StartDate
              AND StartTime < @EndDate";

            var result = await connection.QueryAsync<Appointment.Core.Entity.Appointment>(sql, new
            {
                DoctorId = doctorId,
                Status = Appointment.Core.Entity.AppointmentStatus.Cancelled,
                 StartDate = dateTime,
                EndDate = endDate
            });

            return result.ToList();
        }
        public async Task<List<Appointment.Core.Entity.Appointment>> GetPatientAppointments(int patientId, DateTime? date)
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            DateTime dateTime;
            if (date.HasValue == false)
            {
                dateTime = DateTime.Now;
            }
            else
            {
                dateTime = date.Value.Date;
            }
               
            var endDate = dateTime.AddDays(1);
            var sql = @"
            SELECT *
             FROM Appointments
             WHERE PatientId = @PatientId
             AND Status != @Status
             AND StartTime >= @StartDate
              AND StartTime < @EndDate";


            var result = await connection.QueryAsync<Appointment.Core.Entity.Appointment>(sql, new
            {
                PatientId = patientId,
                Status = Appointment.Core.Entity.AppointmentStatus.Cancelled,
                StartDate = dateTime,
                EndDate = endDate
            });
        

            return result.ToList();
        }
      
    }
}
