using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Response
{
    public class AddDocotr
    {
        public string? Name { get; set; }
        public int? age
        {
            get; set;
        }
        public string? Description { get; set; }
        public int? DepartmantID { get; set; }
       
    }
}
