using Microsoft.EntityFrameworkCore;
using Patient.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.ContextFolder
{
    public  class Contextpatient :DbContext
    {
        public Contextpatient(DbContextOptions<Contextpatient> option): base(option) 
        {

        }
        public DbSet<patient>  patients { get; set; }
    }
}
