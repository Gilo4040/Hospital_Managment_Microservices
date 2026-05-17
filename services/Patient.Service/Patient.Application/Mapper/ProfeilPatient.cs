using AutoMapper;
using Patient.Application.Request;
using Patient.Application.Response;
using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Profeil
{
    public class ProfeilPatient: Profile
    {
        public ProfeilPatient()
        { 

            CreateMap<patient,RequestPatient>().ReverseMap();
            CreateMap<patient, PatientResponse>().ReverseMap();
        
        }
    }
}
