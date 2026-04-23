using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Core.Entity
{
   public  enum AppointmentStatus
    {
        Pending,    // لسه متحجز
        Confirmed,  // اتأكد
        Cancelled,  // اتلغى
       
    }
}
