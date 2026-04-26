
using Appoinment.api.Extenstion;
using Appoinment.Core.Repositry;
using Appoinment.Infrastrucure.ImplementRepositry;
using Appointment.Application.GrpcServices;
using Appointment.Application.Query;
using Doctor.Grpc;
using System.Reflection;

namespace Appoinment.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddGrpcClient<DoctorService.DoctorServiceClient>(o => o.Address = new Uri(builder.Configuration["GrpcSettings:DoctorUrl"])
                );
            builder.Services.AddGrpcClient<Patient.Grpc.PatientService.PatientServiceClient>
                (o => o.Address = new Uri(builder.Configuration["GrpcSettings:PatientUrl"]));
            builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectAllAppointment))));
            builder.Services.AddScoped<GrpcPatientServiceDescription>();
            builder.Services.AddScoped<GrpcDocotrServiceDescription>();
            builder.Services.AddScoped<AppointmentRepositry, ImplementAppointmentInterface>();

            var app = builder.Build();

          
             app.MigrateDatabase();
           // AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
