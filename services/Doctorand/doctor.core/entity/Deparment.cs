using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.core.entity
{
     public class Deparment:BaseClass
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
       

    }
}
