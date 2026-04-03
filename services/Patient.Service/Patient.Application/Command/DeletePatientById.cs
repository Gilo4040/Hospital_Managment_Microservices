using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Command
{
    public class DeletePatientById:IRequest<bool>
    {
        public int Id { get; set; }
        public DeletePatientById(int Id )
        {
          this.Id = Id;

        }
    }
}
