using doctor.core.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace doctor.core.repositry
{
    public interface IrepositryDoctor : Genericrepositry<Doctor, Deparment>
    {
        //Task ListOfELementWithCondation(Expression<Func<Doctor, bool>> expression);
    }
}
