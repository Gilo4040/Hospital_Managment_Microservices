using AutoMapper;
using doctor.application.Query;
using doctor.application.Response;
using doctor.core.entity;
using doctor.core.repositry;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.handler.QueryHandler
{
    internal class SelectListOfDocotorWithCondationHandler : IRequestHandler<SelectListOfDocotorWithCondation, List<ResponselistOfDoctors>>
    {
        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<SelectListOfDocotorWithCondationHandler> logger;
        public SelectListOfDocotorWithCondationHandler(ILogger<SelectListOfDocotorWithCondationHandler> log, IMapper Prof,  IrepositryDoctor Doctors)
        {
            this.logger = log;
            Profile= Prof;
            this.Doctors = Doctors;


        }
        public async Task<List<ResponselistOfDoctors>> Handle(SelectListOfDocotorWithCondation request, CancellationToken cancellationToken)
        {
            
            var result = await Doctors.ListOfELementWithCondation(request.Expression,request.expres);
            var element = Profile.Map<List<ResponselistOfDoctors>>(result);
            if (element == null)
            {

                logger.LogInformation("the process is  not sucssedd ");
            }
            logger.LogInformation("the process is sucssedd ");

            return element;
        }
     
    }
}
