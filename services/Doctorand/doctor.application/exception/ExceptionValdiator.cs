using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.exception
{
    public  class ExceptionValdiator:ApplicationException
    {
        public Dictionary<string , string[]> ErrorValditaors { get; set; }= new Dictionary<string , string[]>();
        //public ExeptionValdiator():base("error that collect in process valditors")
        //{
        //    ErrorValditaors = new Dictionary<string , string[]>();
        //}
        public ExceptionValdiator(IEnumerable<ValidationFailure> errors) : base("error that collect in process valditors")
        {
            ErrorValditaors = errors.GroupBy(x => x.PropertyName,x=>x.ErrorMessage).ToDictionary(x=>x.Key,x=>x.ToArray());
        }
       
    }
}
