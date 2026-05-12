using Grpc.Core;
using MediatR;
using Patient.Application.Query;
using Patient.Grpc;

namespace Patient.Api.Services
{
    public class PatientServiceGrpc: PatientService.PatientServiceBase
    {
        private readonly IMediator mediator;
        public PatientServiceGrpc(IMediator mediat)
        {
            mediator=mediat;
        }
 
        public  override async Task<PatientRespons> GetPatientById(PatientRequest request, ServerCallContext context)
        {

            var result = new SelectNameBYId(request);
            var elemnt =  await  mediator.Send(result);

            if (elemnt == null)
            {
                return new PatientRespons
                {
                    Id = 0,
                    Name = ""
                };
            }

            return elemnt;
          

        }
    }
}
