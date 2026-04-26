using Appointment.Application.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Query
{
    public class SelectAllAppointment:IRequest<List<AppointmentRsponse>>
    {
        public DateTime? DateTime { get; set; }
        public SelectAllAppointment(DateTime? Date)
        {
            DateTime = Date;

        }
    }
}
