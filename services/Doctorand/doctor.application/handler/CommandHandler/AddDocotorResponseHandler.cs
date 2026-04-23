using AutoMapper;
using doctor.application.Command;
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

namespace doctor.application.handler.CommandHandler
{
    public class AddDocotorResponseHandler: IRequestHandler<AddDocotorResponse, bool>
    {
        private IrepositryDoctor Doctors;
        private IMapper Profile;
        public ILogger<AddDocotorResponseHandler> logger;
        public AddDocotorResponseHandler(IrepositryDoctor Doc, IMapper pro, ILogger<AddDocotorResponseHandler> log)
        {
            Doctors = Doc;
            Profile = pro;
            logger = log;

        }
        public async Task<bool> Handle(AddDocotorResponse request, CancellationToken cancellationToken)
        {

            var elemnet = request.AddDoctors;
            var AddElement = Profile.Map<doctor.core.entity.Doctor>(elemnet);
            if (elemnet == null)
                return false;
            return await Doctors.AddElement(AddElement);

        }
    }
}
