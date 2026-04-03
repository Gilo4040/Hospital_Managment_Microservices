using FluentValidation;
using Patient.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Validator
{
    public class SelectValidator:AbstractValidator<PatientResponse>
    {
        public SelectValidator()
        
        { 

            RuleFor(x => x.Name).NotEmpty()
                 .WithMessage("the name must be found")
                  .MaximumLength(12)
                  .WithMessage("name cant be 13 char")
                  .MinimumLength(2).
                  WithMessage("name must be more than 2 ").
                  NotNull();
            RuleFor(x => x.age).NotEmpty().WithMessage("the age must be found ").NotNull();
            

        
        
        }
    }
}
