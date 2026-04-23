using Appointment.Application.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Query
{
    public  class SelectAppointmentpatientByID:IRequest<AppointmentRsponse>
    {
        public int id {  get; set; }
        public DateTime? date { get; set; } 
        public SelectAppointmentpatientByID(int id,DateTime? dateTime )
        {
           this.id = id;    
            date= dateTime;

        }
    }
}
