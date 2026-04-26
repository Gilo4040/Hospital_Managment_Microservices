using Appointment.Application.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Command
{
    public  class AddAppointment:IRequest<bool>
    {
        public AddAppointmentRequest add { get; set;}
        public AddAppointment(AddAppointmentRequest add)
        
        { 
            this.add = add;
        
        }
    }
}
