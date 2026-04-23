using MediatR;
using Patient.Application.Query;
using Patient.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.QueryHandler
{
    public class SelectNameBYIdHandler:IRequestHandler<SelectNameBYId,PatientRespons>
    {
        public Core.Repositry.PatientRepositry patientReposit;
        public SelectNameBYIdHandler(Core.Repositry.PatientRepositry patientRe)
        {
            patientReposit = patientRe;
        }

        public async Task<PatientRespons> Handle(SelectNameBYId request, CancellationToken cancellationToken)
        {
            var result = await  patientReposit.GetPatientByid(request.id);

            var element = new PatientRespons { Id=result.Id,Name=result.Name};
            return element;
        }
    }
}
