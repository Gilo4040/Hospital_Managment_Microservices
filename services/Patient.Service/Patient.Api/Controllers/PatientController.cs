using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Application.Exetiention;
using Patient.Application.Query;
using Patient.Application.Request;
using Patient.Application.Response;

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
        public async Task<List<PatientResponse>> GetAllPatientWithCondation([FromQuery] RequestPatient patient)
        {
            var elment = new  SelectListOfPatient(patient.expression());

             var result = await mediator.Send(elment);
               Ok( result);


       
       }
        [HttpGet("GetallPatient")]
        public async Task<List<PatientResponse>> GetAllPatient()
        {
            var elment = new ListOfPatiens();

            var result = await mediator.Send(elment);
             Ok (result);



        }


    }
}
