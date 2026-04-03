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
    public class ListOfEmployeeResponseHandler : IRequestHandler<ListOfDoctorsResponse, List<ResponselistOfDoctors>>
    {

        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<ListOfEmployeeResponseHandler> logger;
        public ListOfEmployeeResponseHandler(IrepositryDoctor Doc,IMapper pro, ILogger<ListOfEmployeeResponseHandler> log)
        {
            Doctors = Doc;
            Profile = pro;
            logger = log;

        }

        public async Task<List<ResponselistOfDoctors>> Handle(ListOfDoctorsResponse request, CancellationToken cancellationToken)
        {
          var includes=  request.exp;
          var result= await Doctors.ListOfELement(includes);
           var element = Profile.Map< List<ResponselistOfDoctors>>(result);
            if (element==null)
            {
                
                logger.LogInformation("the process is  not sucssedd ");
            }
            logger.LogInformation("the process is sucssedd ");

            return element;

        }
    }
}
