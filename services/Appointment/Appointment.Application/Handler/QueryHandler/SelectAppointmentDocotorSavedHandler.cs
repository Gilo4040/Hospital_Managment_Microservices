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
    public class SelectAppointmentDocotorSavedHandler : IRequestHandler<SelectAppointmentDocotorSaved, List<AppointmentRsponse>>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<SelectAppointmentpatientByIdHandler> logger;
        private readonly GrpcPatientServiceDescription patient;
        private readonly GrpcDocotrServiceDescription grpcDocotrService;

        public SelectAppointmentDocotorSavedHandler(ILogger<SelectAppointmentpatientByIdHandler> log,
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
        public async Task<List<AppointmentRsponse>> Handle(SelectAppointmentDocotorSaved request, CancellationToken cancellationToken)
        {
            var Appointment = await appointmentRepositry.GetDoctorAppointments(request.Id, request.Date);
            var docotr = await grpcDocotrService.DoctorDescription(request.Id);
            List<AppointmentRsponse> appointmentRsponses = new List<AppointmentRsponse>();
            foreach (var ap in Appointment)
            {
                var Description = await patient.GetPatient(request.Id);
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
                    Notes = ap.Notes,
                    PhoneDoctor=docotr.Phone
                    







                });

                

            }
            return appointmentRsponses;
        }
    }
}
