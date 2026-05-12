using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Request
{
    public class AddAppointmentRequest
    {
        public int Id { get; set; }

        public int IdDocotr { get; set; }
        public int IdPatient { get; set; }



        public DateTime StartTime { get; set; }
        public string? Notes { get; set; }







    }
}
