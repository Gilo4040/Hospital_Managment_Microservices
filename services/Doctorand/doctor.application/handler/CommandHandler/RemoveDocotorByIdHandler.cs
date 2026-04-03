using AutoMapper;
using doctor.application.Command;
using doctor.core.repositry;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.handler.CommandHandler
{
    public class RemoveDocotorByIdHandler : IRequestHandler<RemoveDocotorById, bool>
    {
        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<AddDocotorResponse> logger;
        public RemoveDocotorByIdHandler(IrepositryDoctor Doc, IMapper pro, ILogger<AddDocotorResponse> log)
        {
            Doctors = Doc;
            Profile = pro;
            logger = log;

        }
        public async Task<bool> Handle(RemoveDocotorById request, CancellationToken cancellationToken)
        {
            var elementById= request.Id;
           return await  Doctors.DeleteElement(elementById);

           
        }
    }
}
