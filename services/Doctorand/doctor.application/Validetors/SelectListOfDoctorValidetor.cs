using doctor.application.Command;
using doctor.application.Response;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.application.Validetors
{
    public  class SelectListOfDoctorValidetor:AbstractValidator<AddDocotorResponse>
    {
        public SelectListOfDoctorValidetor() {
            RuleFor(x => x.AddDoctors.Name)
                 .NotEmpty()
                 .WithMessage("the name must be found")
                  .MaximumLength(12)
                  .WithMessage("name cant be 13 char")
                  .MinimumLength(2).
                  WithMessage("name must be more than 2 ").
                  NotNull();

            RuleFor(x => x.AddDoctors.age)
                .NotEmpty()
                .NotNull()
                .WithMessage("the name must be found")
                 .GreaterThan(25)
                
                 .LessThan(65)
                 .WithMessage("the age must be renge in 26 ,64");


                  

        
        }
    }
}
