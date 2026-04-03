using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patient.Core.Entity;
using Patient.Core.Repositry;
using Patient.Infrastructure.ContextFolder;
using Patient.Infrastructure.ImplementRepositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.Exetientation2
{
    public static class seitpro
    {
        public static IServiceCollection AddSeti(this IServiceCollection service, IConfiguration conf)
        {
            service.AddDbContext<Contextpatient>(option=>option.UseNpgsql(conf.GetConnectionString("DefaultConnection")));
            service.AddScoped<PatientRepositry, Implamentpatient>();
            return service;

        }
    }
}
