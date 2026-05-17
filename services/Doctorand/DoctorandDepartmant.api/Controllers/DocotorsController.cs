using doctor.application.Command;
using doctor.application.Condition;
using doctor.application.Query;
using doctor.application.Response;
using doctor.core.entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorandDepartmant.api.Controllers
{

    public class DoctorsController : FatherController
    {
        

        
            private readonly IMediator _mediator;
            private readonly ILogger<DoctorsController> _logger;

            public DoctorsController(IMediator mediator, ILogger<DoctorsController> logger)
            {
                _mediator = mediator;
                _logger = logger;
            }

            // GET: api/Doctors/all
            [HttpGet("all", Name = "GetAllDoctors")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<ResponselistOfDoctors>>> GetAllDoctors()
            {
                var query = new ListOfDoctorsResponse(x => x.Deparment);
                var result = await _mediator.Send(query);

                return Ok(result);
            }

            // GET: api/Doctors/search
            [HttpGet("search", Name = "SearchDoctors")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<ResponselistOfDoctors>>> SearchDoctors(
                [FromQuery] ResponseListOfDoctorWithCondition request)
            {
                var query = new SelectListOfDocotorWithCondation(
                    ExtntionCondition.Express<doctor.core.entity.Doctor, ResponseListOfDoctorWithCondition>(request),
                    x => x.Deparment);

                var result = await _mediator.Send(query);

                return Ok(result);
            }

           
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<ActionResult> AddDoctor([FromBody] AddDocotr doctor)
            {
                var command = new AddDocotorResponse(doctor);
                var result = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetAllDoctors), result);
            }

            
            [HttpPut]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<ResponselistOfDoctors>> UpdateDoctor(
                [FromBody] ResponselistOfDoctors update)
            {
                var command = new UpdateDocotrResponse(update);
                var result = await _mediator.Send(command);

                return Ok(result);
            }

          
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            public async Task<ActionResult> DeleteDoctor(int id)
            {
                var command = new RemoveDocotorById(id);
                await _mediator.Send(command);

                return NoContent();
            }
    }




    
}
