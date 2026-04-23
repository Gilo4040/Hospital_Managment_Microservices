using Appoinment.Core.Repositry;
using Appointment.Application.Query;
using Appointment.Application.Request;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Handler.QueryHandler
{
    public class SelectAppointmentpatientByIdHandler : IRequestHandler<SelectAppointmentpatientByID, AppointmentRsponse>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<SelectAppointmentpatientByIdHandler> logger;

        public SelectAppointmentpatientByIdHandler(ILogger<SelectAppointmentpatientByIdHandler> log, AppointmentRepositry appointmentReposi)
        {
            logger = log;

            appointmentRepositry=appointmentReposi;
        }
        public Task<AppointmentRsponse> Handle(SelectAppointmentpatientByID request, CancellationToken cancellationToken)
        {
           
        }
    }
}
