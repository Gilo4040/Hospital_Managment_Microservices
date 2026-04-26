using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Core.Entity
{
    public  class Appointment
    {
       public int Id { get; set; }

        // العلاقات
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        // وقت الموعد
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // حالة الموعد
        public AppointmentStatus Status { get; set; }

        // ملاحظات
        public string? Notes { get; set; }

   
       
    }
}
