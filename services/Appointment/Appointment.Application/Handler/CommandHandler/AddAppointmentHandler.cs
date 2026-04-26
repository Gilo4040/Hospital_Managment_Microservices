using Appoinment.Core.Repositry;
using Appointment.Application.Command;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Handler.CommandHandler
{
    public class AddAppointmentHandler : IRequestHandler<AddAppointment, bool>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<AddAppointmentHandler> logger;


        public AddAppointmentHandler(ILogger<AddAppointmentHandler> log,
            AppointmentRepositry appointmentReposi)

        {
            logger = log;

            appointmentRepositry = appointmentReposi;

        }

        public async Task<bool> Handle(AddAppointment request, CancellationToken cancellationToken)
        {
            if (request.add==null)
            {
               

            }
            var requestAppointment = request;

            var appointment = new Appointment.Core.Entity.Appointment
            {
                DoctorId = requestAppointment.add.IdDocotr,
                StartTime = requestAppointment.add.StartTime,
                PatientId = requestAppointment.add.IdPatient
            };
           var result=  await appointmentRepositry.AddAppoinment(appointment);
            if (result== true)
            {
                return true;

            }
           
            
                return false;
            
        }
    }
}
