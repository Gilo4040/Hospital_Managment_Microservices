using Appoinment.Core.Repositry;
using Appointment.Application.Command;
using Appointment.Application.GrpcServices;
using Appointment.Application.Handler.QueryHandler;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Handler.CommandHandler
{
    public  class CancelAppointmentHandler:IRequestHandler<CancelAppointment,bool>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<CancelAppointmentHandler> logger;
     

        public CancelAppointmentHandler(ILogger<CancelAppointmentHandler> log,
            AppointmentRepositry appointmentReposi)
      
        {
            logger = log;

            appointmentRepositry = appointmentReposi;
           
        }

        public async Task<bool> Handle(CancelAppointment request, CancellationToken cancellationToken)
        {
            if (request.DateTime==null)
            {
                request.DateTime = DateTime.Now;

            }
             var result= await    appointmentRepositry.CancelAppoinment(request.id,request.DateTime);
            if (result==true)
            {
                return true;

            }
            return false;

        }
    }
}
