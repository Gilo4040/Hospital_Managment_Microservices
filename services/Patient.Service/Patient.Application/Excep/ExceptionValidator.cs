using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Exeption
{
    public class ExceptionValidator:ApplicationException
    {
        public Dictionary<string, string[]> exceptionvalidator= new Dictionary<string, string[]>();
        public ExceptionValidator(IEnumerable<ValidationFailure> validationfailures) : base("erorr for the patien validator")
        {
            validationfailures.GroupBy(x=>x.PropertyName,x=>x.ErrorMessage).ToDictionary(x=>x.Key,x=>x.ToArray());
        
        
        }

    }
}
