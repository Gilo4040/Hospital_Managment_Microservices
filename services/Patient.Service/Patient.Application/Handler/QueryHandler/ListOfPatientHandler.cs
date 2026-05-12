using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Patient.Application.Query;
using Patient.Application.Response;
using Patient.Core.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Handler.QueryHandler
{
    public class ListOfPatientHandler : IRequestHandler<ListOfPatiens, List<PatientRequest>>
    {
        public PatientRepositry  Patient;
        public ILogger<ListOfPatientHandler> logger;
        public IMapper mapper;
        public ListOfPatientHandler(PatientRepositry Patie, ILogger<ListOfPatientHandler> logg, IMapper mapp)
        {
            Patient = Patie;
            logger= logg;
            mapper = mapp;

        }
        public async Task<List<PatientRequest>> Handle(ListOfPatiens request, CancellationToken cancellationToken)
        {
             var elemnt=  await Patient.ListofPatients();
             return    mapper.Map<List<PatientRequest>>(elemnt);
           
           
        }
    }
}
