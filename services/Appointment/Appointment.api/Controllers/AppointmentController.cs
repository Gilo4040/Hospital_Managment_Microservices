using Appointment.Application.Query;
using Appointment.Application.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator mediator;
       
        public AppointmentController(  IMediator media)
        {
            mediator = media;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetAppointmentPatient(int Id , DateTime? dateTime)
        {
            var appointment= new SelectAppointmentpatientByID (Id,dateTime);
            return  await mediator.Send(appointment);


        }

    }
}
