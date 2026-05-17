using Appointment.Application.Command;
using Appointment.Application.Query;
using Appointment.Application.Request;
using Appointment.Core.Entity;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Appointment.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet("by-patient")]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetByPatient(
            [FromQuery] int id,
            [FromQuery] DateTime? dateTime)
        {
            var query = new SelectAppointmentpatientByID(id, dateTime);
            return Ok(await _mediator.Send(query));
        }

      
        [HttpGet("by-doctor")]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetByDoctor(
            [FromQuery] int id,
            [FromQuery] DateTime? dateTime)
        {
            var query = new SelectAppointmentDocotorSaved(id, dateTime);
            return Ok(await _mediator.Send(query));
        }

       
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<(DateTime start, DateTime end)>>> GetAvailable(
            [FromQuery] int id,
            [FromQuery] DateTime? dateTime)
        {
            var query = new SelectAppointmentDocotorIdAvailable(id, dateTime);
            return Ok(await _mediator.Send(query));
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetAll(DateTime? dateTime)
        {
            var query = new SelectAllAppointment(dateTime);
            return Ok(await _mediator.Send(query));
        }

        
        [HttpPost]
        public async Task<ActionResult<bool>> Add([FromBody] AddAppointmentRequest add)
        {
            var command = new AddAppointment(add);
            return Ok(await _mediator.Send(command));
        }

        
        [HttpPut("cancel")]
        public async Task<ActionResult<bool>> Cancel(
            [FromQuery] int id,
            [FromQuery] DateTime? date)
        {
            var command = new CancelAppointment(id, date);
            return Ok(await _mediator.Send(command));
        }
    }
}
