using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Command
{
    public class CancelAppointment:IRequest<bool>
    {
        public int id { get; set; }
        public DateTime? DateTime { get; set; }
        public CancelAppointment(int Id , DateTime? Date)
        {
            id = Id;
            DateTime = Date;

        }
    }
}
