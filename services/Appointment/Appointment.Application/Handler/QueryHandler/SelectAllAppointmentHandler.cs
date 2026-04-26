using Appoinment.Core.Repositry;
using Appointment.Application.GrpcServices;
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
    public  class SelectAllAppointmentHandler:IRequestHandler<SelectAllAppointment,List<AppointmentRsponse>>
    {

        public AppointmentRepositry appointmentRepositry;
        public ILogger<SelectAllAppointmentHandler> logger;
        private readonly GrpcPatientServiceDescription patient;
        private readonly GrpcDocotrServiceDescription grpcDocotrService;

        public SelectAllAppointmentHandler(ILogger<SelectAllAppointmentHandler> log,
            AppointmentRepositry appointmentReposi,
            GrpcPatientServiceDescription patienDescription,
             GrpcDocotrServiceDescription grpcDocotr
            )
        {
            logger = log;

            appointmentRepositry = appointmentReposi;
            patient = patienDescription;
            grpcDocotrService = grpcDocotr;
        }

        public  async Task<List<AppointmentRsponse>> Handle(SelectAllAppointment request, CancellationToken cancellationToken)
        {
            if (request.DateTime==null)
            {
                request.DateTime = DateTime.Now;

            }
            var Appointment = await appointmentRepositry.appoinments(request.DateTime.Value);


          
            List<AppointmentRsponse> appointmentRsponses = new List<AppointmentRsponse>();
            foreach (var ap in Appointment)
            {
                var docotr = await grpcDocotrService.DoctorDescription(ap.DoctorId);
                var Description = await patient.GetPatient(ap.PatientId);
                appointmentRsponses.Add(new AppointmentRsponse
                {
                    Id = ap.Id,

                    IdPatient = ap.PatientId,
                    Namepatient = Description.Name,

                    NameDocotor = docotr.Name,
                    specialization = docotr.Specialization,
                    StartTime = ap.StartTime,
                    EndTime = ap.EndTime,
                    Status = ap.Status,
                    Notes = ap.Notes







                });


            }
            return appointmentRsponses;
        }
    }
}
