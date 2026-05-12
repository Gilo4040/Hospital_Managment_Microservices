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

    public class DocotorsController : FatherController
    {
        public IMediator mediator;
        public ILogger<DocotorsController> _logger;
        public DocotorsController(IMediator med, ILogger<DocotorsController> _logger)
        {
            this.mediator = med;
            this._logger = _logger;

        }
        [HttpGet("all",Name = "SelectListOfDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<ResponselistOfDoctors>>> SelectListOfDoctors()
        {
            var result = new ListOfDoctorsResponse(x => x.Deparment);
            var elemnts = await mediator.Send(result);
            return Ok(elemnts);



        }
        [HttpDelete("{id}", Name = "DeleteDocotr")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var result = new RemoveDocotorById(id);
            await mediator.Send(result);


            return NoContent();






        }
        [HttpPost(Name ="UpadateDocotr")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponselistOfDoctors>> UpdateDocotrs([FromBody]ResponselistOfDoctors UPdate)
        {
            var result = new UpdateDocotrResponse (UPdate);
           var elemnt =  await mediator.Send(result);
            return Ok(elemnt);


          


        }
        [HttpGet("search",Name = "Doctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<ResponselistOfDoctors>>> SelectListOfDoctors([FromQuery] ResponseListOfDoctorWithCondition request)
        {
           
            
            

            var result = new SelectListOfDocotorWithCondation(ExtntionCondition.Express<doctor.core.entity.Doctor, ResponseListOfDoctorWithCondition>(request), x => x.Deparment);
            var elemnt = await mediator.Send(result);
            return Ok(elemnt);

        }
        [HttpPost("AddDocotrs")]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task <ActionResult<bool>> AddDocotrs(AddDocotr Docotr )
        {
            var result = new AddDocotorResponse(Docotr);
            var elemnt = await mediator.Send(result);
            return Created();


        }


    }
}
