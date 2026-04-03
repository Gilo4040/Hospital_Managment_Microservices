using AutoMapper;
using doctor.application.Response;
using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.mapper
{
    public class DocotorProfeile:Profile
    {
        public DocotorProfeile() 
        {
            CreateMap<Doctor, ResponselistOfDoctors>()
               .ForMember(dest => dest.DeparmentResp, opt => opt.MapFrom(src => src.Deparment));
            CreateMap<Doctor , AddDocotr>().ReverseMap();
            CreateMap<Deparment,DepartmantResponse>().ReverseMap();
      


    }
}
}
