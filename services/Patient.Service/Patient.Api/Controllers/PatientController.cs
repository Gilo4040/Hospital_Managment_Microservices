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
        private readonly IMediator _mediator;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IMediator mediator, ILogger<PatientController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

     
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PatientResponse>>> GetPatientsByCondition(
            [FromQuery] RequestPatient patient)
        {
            var query = new SelectListOfPatient(patient.expression());
            var result = await _mediator.Send(query);

            return Ok(result);
        }

     
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PatientResponse>>> GetAllPatients()
        {
            var query = new ListOfPatiens();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddPatient([FromBody] RequestPatient request)
        {
            var command = new AddPatientRequest(request);
            await _mediator.Send(command);

            return Created();
        }

       
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdatePatient([FromBody] RequestPatient request)
        {
            var command = new Application.Command.UpdatePatientRequest(request);
            await _mediator.Send(command);

            return Ok();
        }

       
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var command = new DeletePatientById(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
