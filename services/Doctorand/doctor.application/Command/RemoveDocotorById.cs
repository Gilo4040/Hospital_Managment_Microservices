using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Command
{
    public class RemoveDocotorById:IRequest<bool>
    {
        public int Id { get; set; }
        public RemoveDocotorById( int id)
        {
            Id = id;

        }
    }
}
