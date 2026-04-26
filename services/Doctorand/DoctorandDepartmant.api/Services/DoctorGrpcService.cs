using doctor.application.Query;
using Doctor.Grpc;
using Grpc.Core;
using MediatR;

namespace DoctorandDepartmant.api.Services
{
    public class DoctorGrpcService : DoctorService.DoctorServiceBase
    {
        private readonly  IMediator _mediator;
        public DoctorGrpcService(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public override async Task<DoctorResponse> GetDoctorById(DoctorRequest request, ServerCallContext context)
        {
            var elemnt = new SelectNameDocotorById(request);
          return   await _mediator.Send(elemnt);




        }
        
       
    }
}
