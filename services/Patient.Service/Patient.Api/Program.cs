
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Patient.Api.extien;
using Patient.Api.Services;
using Patient.Application.Exetiention;
using Patient.Application.Query;
using Patient.Infrastructure.ContextFolder;
using Patient.Infrastructure.Exetientation2;
using System.Reflection;
using System.Threading.Tasks;

namespace Patient.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(7250, o =>
            //    {
            //        o.UseHttps();
            //        o.u
            //        o.Protocols = HttpProtocols.Http1AndHttp2;
            //    });
            //});
            

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

            await app.migrateDataBase<Contextpatient>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGrpcService<PatientServiceGrpc>();
            app.MapControllers();
            

            app.Run();
        }
    }
}
