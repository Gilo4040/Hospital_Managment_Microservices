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
    public class ImplementDoctor : implementGeneric<doctor.core.entity.Doctor,Deparment>, IrepositryDoctor
    {
        private ContextEntity Db;

        public ImplementDoctor(ContextEntity Db) : base(Db)
        {
            this.Db = Db;
        }
    }
}
