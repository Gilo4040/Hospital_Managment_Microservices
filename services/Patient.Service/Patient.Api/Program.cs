
using logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Patient.Api.extien;
using Patient.Api.Services;
using Patient.Application.Exetiention;
using Patient.Application.Query;
using Patient.Infrastructure.ContextFolder;
using Patient.Infrastructure.Exetientation2;
using Serilog;
using System.Reflection;
using System.Threading.Tasks;

namespace Patient.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog(follow.ConfigureLogger);
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(8080, o =>
                {
                    o.Protocols = HttpProtocols.Http1;
                });
                options.ListenAnyIP(5001, o =>
                {
                    o.Protocols = HttpProtocols.Http2;
                });


            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Console.WriteLine("Before Build");
            builder.Services.AddMediatR(co => co.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectPatientByid))));
            builder.Services.AddExte();
            builder.Services.AddSeti(builder.Configuration);

            Console.WriteLine("Before Build");
            builder.Services.AddGrpc();

            Console.WriteLine("Before Build");
            var app = builder.Build();
            Console.WriteLine("After Build");

            await app.MigrateDatabase<Contextpatient>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           

            app.UseAuthorization();

          
            app.MapControllers();
            app.MapGrpcService<PatientServiceGrpc>();

             await app.RunAsync();
        }
    }
}
