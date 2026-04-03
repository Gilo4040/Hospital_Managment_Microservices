using doctor.application.Response;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Command
{
    public  class AddDocotorResponse:IRequest<bool>
    {
        public AddDocotr AddDoctors;
        public AddDocotorResponse( AddDocotr doctors) 
        {
            AddDoctors = doctors;

         }

    }
}
