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
    public class UpdateDocotrResponeHandler : IRequestHandler<UpdateDocotrResponse, ResponselistOfDoctors>
    {
        public ILogger<UpdateDocotrResponeHandler> Logger {  get; set; }
        public IrepositryDoctor IrepositryDoctor { get; set; }
        public IMapper mapper { get; set; }
        public UpdateDocotrResponeHandler(ILogger<UpdateDocotrResponeHandler> Logger, IrepositryDoctor IrepositryDoc,IMapper Mapp)
        { 
            this.Logger = Logger;
            this.mapper = Mapp;
            this.IrepositryDoctor = IrepositryDoc;
        
        
        }
        public async Task<ResponselistOfDoctors> Handle(UpdateDocotrResponse request, CancellationToken cancellationToken)
        {
            var id = request.responselistOfDocotrs.Id;
              var result = await IrepositryDoctor.SelectElementById(request.responselistOfDocotrs.Id);
            if (result == null)
            {
                Logger.LogInformation($"{id } is not found");
            }
            var ElementDocor= mapper.Map<Doctor>(request);
           var Element =  await IrepositryDoctor.UpdataElement(ElementDocor);
            return  mapper.Map<ResponselistOfDoctors>(Element);


          

           
        }
    }
}
