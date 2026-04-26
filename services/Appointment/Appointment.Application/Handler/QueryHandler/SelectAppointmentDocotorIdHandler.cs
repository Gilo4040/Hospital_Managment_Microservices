using Appoinment.Core.Repositry;
using Appointment.Application.Query;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.Handler.QueryHandler
{
    public class SelectAppointmentDocotorIdHandler : IRequestHandler<SelectAppointmentDocotorIdAvailable, List<(DateTime start, DateTime end)>>
    {
        public AppointmentRepositry appointmentRepositry;
        public ILogger<SelectAppointmentDocotorIdHandler> logger;
        public SelectAppointmentDocotorIdHandler(AppointmentRepositry appointmentRepositr,ILogger<SelectAppointmentDocotorIdHandler> logg)
        {
            this.appointmentRepositry = appointmentRepositr;
            logger=logg;


        }
        public async Task<List<(DateTime start, DateTime end)>> Handle(SelectAppointmentDocotorIdAvailable request, CancellationToken cancellationToken)
        {
            logger.LogInformation("the process of DocotorAppointment available");
           var result= await  appointmentRepositry.GetDoctorAvailable(request.Id,request.Date.Value);
            if (result!=null)
                logger.LogInformation("the process of DocotorAppointment available is scucced");
            return result;
        }
    }
}
