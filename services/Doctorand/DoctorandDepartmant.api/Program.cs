
using doctor.application.Extenstion2;
using doctor.application.Query;
using doctor.infrastructure.Context;
using doctor.infrastructure.Extenstion;

using System.Reflection;
using DoctorandDepartmant.api.Exctention;
using Doctor.Grpc;
using DoctorandDepartmant.api.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Threading.Tasks;
using MassTransit;
using DoctorandDepartmant.api.Consumer;
using logging;
using Serilog;

namespace DoctorandDepartmant.api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog(follow.ConfigureLogger);
                builder.WebHost.ConfigureKestrel( options =>
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
                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.serviceCollection(builder.Configuration);
                builder.Services.AddMediatR(co => co.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectElementById))));

                builder.Services.ServiceColl();
                builder.Services.AddGrpc(options => { options.EnableDetailedErrors = true; });
                builder.Services.AddMassTransit(o => {
                    o.AddConsumer<ConsumerEvent>();
                    o.UsingRabbitMq((c, b) =>
                    {
                        var connection = builder.Configuration.GetConnectionString("RabbitMQ");

                        b.Host(connection);
                        b.ReceiveEndpoint("appointment-queue", e =>
                        {
                            e.ConfigureConsumer<ConsumerEvent>(c);
                        });

                    });
                });
                builder.Services.AddMassTransitHostedService();

                var app = builder.Build();
                await app.migrateDataBase<ContextEntity>();


                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseAuthorization();

               
                app.MapControllers();
                app.MapGrpcService<DoctorGrpcService>();

                app.Run();

            }
            catch(Exception er)
            {
                Console.WriteLine("Application failed to start: " + er);
                throw;
            }
        }
    }
}
