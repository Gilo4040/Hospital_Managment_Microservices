using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Command;
using Patient.Application.Exetiention;
using Patient.Application.Query;
using Patient.Application.Request;
using Patient.Application.Response;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Patient.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public IMediator mediator;
        public ILogger<PatientController> _logger;
         public PatientController(IMediator medi, ILogger<PatientController> _log) 
        
        { 
            mediator = medi;
            _logger = _log;
        }
        [HttpGet("GetallPatientWithCondation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task< ActionResult<List<PatientRequest>>> GetAllPatientWithCondation([FromQuery] RequestPatient patient)
        {
            var elment = new  SelectListOfPatient(patient.expression());

             var result = await mediator.Send(elment);
               return Ok( result);


       
       }
        [HttpGet("GetallPatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< ActionResult<List<PatientRequest>>> GetAllPatient()
        {
            var element = new ListOfPatiens();

            var result = await mediator.Send(element);
             return Ok (result);



        }
        [HttpPost("AddPatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
  
        public async Task<ActionResult> AddPatient(RequestPatient request)
        {
            var element = new AddPatientRequest(request);
            var result = await mediator.Send(element);
            return NoContent();

        }
        [HttpPut("updatePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdatePatient(RequestPatient request)
        {
            var element = new AddPatientRequest(request);
            var result = await mediator.Send(element);
            return NoContent();

        }
        [HttpDelete("DeletePatient/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var command = new DeletePatientById(id);

            await mediator.Send(command);

            return NoContent();
        }



    }
}
