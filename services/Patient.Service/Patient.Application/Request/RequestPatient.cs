using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Request
{
    public class RequestPatient
    {
       public int? Id { get; set; }  
        public string? Name { get; set; }
        public int? age { get; set; }

        public string? MedicalHistory { get; set; }
    }
}
