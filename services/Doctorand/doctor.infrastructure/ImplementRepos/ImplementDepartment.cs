using doctor.core.entity;
using doctor.core.repositry;
using doctor.infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.ImplementRepos
{
    public class ImplementDepartment : implementGeneric< Deparment,Doctor>, IrepositryDepartmant
    {
        private ContextEntity Context;
        public ImplementDepartment(ContextEntity Db) : base(Db)
        { 
            Context = Db;
        }
    }
}
