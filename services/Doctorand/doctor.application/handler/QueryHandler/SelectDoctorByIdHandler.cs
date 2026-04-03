using AutoMapper;
using doctor.application.Query;
using doctor.application.Response;
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
    public class SelectDoctorByIdHandler : IRequestHandler<SelectElementById, ResponselistOfDoctors>
    {
        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<SelectDoctorByIdHandler> logger;
        public SelectDoctorByIdHandler(IrepositryDoctor Doc, IMapper pro, ILogger<SelectDoctorByIdHandler> log)
        {
            Doctors = Doc;
            Profile = pro;
            logger = log;

        }
        public  async Task<ResponselistOfDoctors> Handle(SelectElementById request, CancellationToken cancellationToken)
        {
          
           var elemnt=  await Doctors.SelectElementById(request.id);
            if ( elemnt==null)
            {
                logger.LogInformation($"{request.id} is not found ");

                
            }
            var result= Profile.Map<ResponselistOfDoctors>(elemnt);
            logger.LogInformation($"{result}   process is succed");
            return result;
           
        }
    }
}
