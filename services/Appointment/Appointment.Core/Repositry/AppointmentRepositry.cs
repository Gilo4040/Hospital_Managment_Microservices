using Appointment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appoinment.Core.Repositry
{
    public interface AppointmentRepositry
    {
        public Task<bool> AddAppoinment(Appointment.Core.Entity.Appointment appoinment);
        public Task<bool> CancelAppoinment( int Id,DateTime? date);

        public Task<List<Appointment.Core.Entity.Appointment>> appoinments(DateTime date);
        public Task<List<Appointment.Core.Entity.Appointment>> GetDoctorAppointments(int doctorId,DateTime? date);
        public Task<List<Appointment.Core.Entity.Appointment>> GetPatientAppointments(int patientId,DateTime? date);
        public Task<List<(DateTime Start, DateTime End)>> GetDoctorAvailable(int doctorId, DateTime date);





    }
}
