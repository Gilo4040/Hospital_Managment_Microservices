using doctor.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Query
{
    public  class SelectElementById:IRequest<ResponselistOfDoctors>
    {
        public int id {  get; set; }
        public SelectElementById( int Id)
        {
            id=Id;
        }
    }
}
