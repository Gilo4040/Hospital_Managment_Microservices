using doctor.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Command
{
    public  class UpdateDocotrResponse :IRequest<ResponselistOfDoctors>
    {
        public ResponselistOfDoctors responselistOfDocotrs { get; set; }
        public UpdateDocotrResponse( ResponselistOfDoctors Re)
        {
            this.responselistOfDocotrs = Re;


        }
    }
}
