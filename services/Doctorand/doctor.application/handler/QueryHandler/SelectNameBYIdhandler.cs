using AutoMapper;
using doctor.application.Query;
using doctor.application.Response;
using doctor.core.repositry;
using Doctor.Grpc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.handler.QueryHandler
{
    public class SelectNameBYIdhandler : IRequestHandler<SelectNameDocotorById, DoctorResponse>
    {
        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<SelectNameBYIdhandler> logger;
        public SelectNameBYIdhandler(IrepositryDoctor Doc, IMapper pro, ILogger<SelectNameBYIdhandler> log)
        {
            Doctors = Doc;
            Profile = pro;
            logger = log;

        }
        public async  Task<DoctorResponse> Handle(SelectNameDocotorById request, CancellationToken cancellationToken)
        {
            var elemnt = await Doctors.SelectElementById(request.Id);
            if (elemnt == null)
            {
                logger.LogInformation($"{request.Id} is not found ");


            }
            var result = new DoctorResponse { Id = elemnt.ID, Name = elemnt.Name, Specialization = elemnt.Description ,Phone=elemnt.Phone};
            logger.LogInformation($"{result}   process is succed");
            return result;
        }
    }
}
