using Appoinment.Core.Repositry;
using Appointment.Application.Command;
using Appointment.Application.Query;
using EventMassage;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public IMediator mediator;
        private readonly IPublishEndpoint publishEndpoint;


        public AddAppointmentHandler(ILogger<AddAppointmentHandler> log,
            AppointmentRepositry appointmentReposi,
            IMediator mediator, IPublishEndpoint publish)
        {
            logger = log;
            publishEndpoint = publish;

            appointmentRepositry = appointmentReposi;
            this.mediator = mediator;
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
                PatientId = requestAppointment.add.IdPatient,
                Status=Core.Entity.AppointmentStatus.Confirmed,
                 Notes=requestAppointment.add.Notes
            };
           var result=  await appointmentRepositry.AddAppoinment(appointment);
            if (result== true)
            {
              var appointmentselect=  new SelectAppointmentpatientByID(requestAppointment.add.IdPatient, requestAppointment.add.StartTime);
                var elemnt= await mediator.Send(appointmentselect);
                 var elementappointment = elemnt.FirstOrDefault();
                var Event = new EventNotfiation
                {
                    Id = elementappointment.Id,
                    Namepatient=elementappointment.Namepatient, 
                    NameDocotor=elementappointment.NameDocotor,
                    StartTime=elementappointment.StartTime,
                    EndTime=elementappointment.EndTime, 
                    Notes=elementappointment.Notes,
                    Phone=elementappointment.PhoneDoctor,



                };
                  await publishEndpoint.Publish(Event);


                return true;
                

            }
           
            
                return false;
            
        }
    }
}
