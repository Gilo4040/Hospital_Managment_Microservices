
using Appoinment.api.Extenstion;
using Appoinment.Core.Repositry;
using Appoinment.Infrastrucure.ImplementRepositry;
using Appointment.Application.GrpcServices;
using Appointment.Application.Query;
using Doctor.Grpc;
using logging;
using MassTransit;
using Serilog;
using System.Reflection;
using System.Threading.Channels;

namespace Appoinment.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host.UseSerilog(follow.ConfigureLogger);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Doctor gRPC Client
            builder.Services.AddGrpcClient<DoctorService.DoctorServiceClient>(o =>
            {
                o.Address = new Uri(builder.Configuration["GrpcSettings:DoctorUrl"] );
            });


            // Patient gRPC Client  
            builder.Services.AddGrpcClient<Patient.Grpc.PatientService.PatientServiceClient>(o =>
            {
                o.Address = new Uri(builder.Configuration["GrpcSettings:PatientUrl"]);
            });
            builder.Services.AddMassTransit(o => {
                o.UsingRabbitMq((c, b) =>
                {
                    var connection = builder.Configuration.GetConnectionString("RabbitMQ");

                    b.Host(connection);

                });
            });
            builder.Services.AddMassTransitHostedService();
           
            builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectAllAppointment))));
            builder.Services.AddScoped<GrpcPatientServiceDescription>();
            builder.Services.AddScoped<GrpcDocotrServiceDescription>();
            builder.Services.AddScoped<AppointmentRepositry, ImplementAppointmentInterface>();

            var app = builder.Build();
            AppContext.SetSwitch(
                   "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true
                                                                        );


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
