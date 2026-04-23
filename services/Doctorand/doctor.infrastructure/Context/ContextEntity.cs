using doctor.core.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctor.infrastructure.Context
{
    public  class ContextEntity:DbContext
    {
        public ContextEntity(DbContextOptions<ContextEntity> options):base(options) 
        { 

        
        }
        public DbSet<doctor.core.entity.Doctor> Doctors {  get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<doctor.core.entity.Doctor>().HasKey(x=>x.ID);
            modelBuilder.Entity<doctor.core.entity.Doctor>().HasOne(x => x.Deparment).WithMany(x => x.Doctors);
            modelBuilder.Entity<Deparment>().HasKey(x=>x.ID);

        }
    }
}
