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
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator mediator;
       
       
        public AppointmentController(  IMediator media)
        {
            mediator = media;

          
        }
        [HttpGet("by-patient")]
        
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetAppointmentPatient(int Id , DateTime? dateTime)
        {
            var appointment= new SelectAppointmentpatientByID (Id,dateTime);
            return  Ok ( await mediator.Send(appointment));


        }
        [HttpGet("by-docotr")]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetDocotrAppointment(int Id , DateTime? dateTime)
        {
            var appointment = new SelectAppointmentDocotorSaved(Id,dateTime);
            return Ok( await mediator.Send(appointment));
        }
        [HttpGet("by-docotorAvailable")]
        public async Task<ActionResult<IEnumerable<(DateTime start, DateTime end)>>> GetAppointmentAvailable(int Id ,DateTime?dateTime)
        {

            var appointment = new SelectAppointmentDocotorIdAvailable(Id, dateTime);
            return Ok ( await mediator.Send(appointment));
        }
        [HttpGet("AllAppointment")]
        public async Task<ActionResult<IEnumerable<AppointmentRsponse>>> GetAllAppointment(DateTime? dateTime)
        {
            var appointment = new SelectAllAppointment(dateTime);
           var  Results= await mediator.Send(appointment);
             return Ok(Results);
           

        }
        [HttpPost("AddAppointment")]
        public async Task <ActionResult<bool>> AddAppointment(AddAppointmentRequest add)
        {
            var Add = new AddAppointment(add);
            var Results = await mediator.Send(Add);
            return Ok(Results);
         
        }
        [HttpPut("CancalAppointment")]
        public async Task<ActionResult<bool>> Cancal(int id , DateTime? date)
        {

            var delete = new CancelAppointment(id ,date);

            var Results = await mediator.Send(delete);
            return Ok(Results);
        }



    }
}
