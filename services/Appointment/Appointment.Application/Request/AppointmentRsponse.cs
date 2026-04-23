using Appointment.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Request
{
    public   class AppointmentRsponse
    {
        public int Id { get; set; }

        public int IdDocotr { get; set; }   
        public int IdPatient {  get; set; } 
        public  string NameDocotor { get; set; }
        public  string Namepatient { get; set; }

   
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        
        public AppointmentStatus Status { get; set; }

        public string? Notes { get; set; }
    }
}
