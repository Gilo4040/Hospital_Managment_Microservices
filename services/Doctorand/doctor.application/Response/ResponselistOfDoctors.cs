using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Response
{
    public class ResponselistOfDoctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age
        {
            get; set;
        }
        public string Description { get; set; }
        public int DepartmantID { get; set; }
        [ForeignKey(nameof(DepartmantID))]
        public DepartmantResponse DeparmentResp { get; set; }
    }
}
