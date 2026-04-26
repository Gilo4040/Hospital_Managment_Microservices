using Appoinment.Core.Repositry;
using Appointment.Application.GrpcServices;
using Appointment.Application.Query;
using Appointment.Application.Request;
using Appointment.Core.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Handler.QueryHandler
{
    public class SelectAppointmentpatientByIdHandler : IRequestHandler<SelectAppointmentpatientByID, List<AppointmentRsponse>>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<SelectAppointmentpatientByIdHandler> logger;
        private readonly GrpcPatientServiceDescription patient;
        private readonly GrpcDocotrServiceDescription grpcDocotrService;

         public SelectAppointmentpatientByIdHandler(ILogger<SelectAppointmentpatientByIdHandler> log, 
             AppointmentRepositry appointmentReposi,
             GrpcPatientServiceDescription patienDescription,
              GrpcDocotrServiceDescription grpcDocotr
             )
        {
            logger = log;

            appointmentRepositry=appointmentReposi;
            patient = patienDescription;
            grpcDocotrService = grpcDocotr;
        }
        public async Task<List<AppointmentRsponse>> Handle(SelectAppointmentpatientByID request, CancellationToken cancellationToken)
        {
            var Appointment=  await  appointmentRepositry.GetPatientAppointments(request.id,request.date);
           
         
            var Description=  await patient.GetPatient(request.id);
            List <AppointmentRsponse> appointmentRsponses = new List <AppointmentRsponse>();
            foreach (var ap in Appointment)
            {
                var docotr = await grpcDocotrService.DoctorDescription(ap.DoctorId);
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
