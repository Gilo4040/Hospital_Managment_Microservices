using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.core.entity
{
     public class Doctor:BaseClass
    {
      
        public string Name { get; set; }
        public int age
        {
            get; set;
        }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int DepartmantID {  get; set; }
        [ForeignKey(nameof(DepartmantID))]
       
        public Deparment Deparment { get; set; }

    }
}
