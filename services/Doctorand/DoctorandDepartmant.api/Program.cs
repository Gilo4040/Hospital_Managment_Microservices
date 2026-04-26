
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

namespace DoctorandDepartmant.api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.WebHost.ConfigureKestrel(options =>
                {
                    options.ListenAnyIP(6566, o =>
                    {
                        //o.UseHttps();
                        o.Protocols = HttpProtocols.Http1AndHttp2;
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
                builder.Services.AddGrpc();

                var app = builder.Build();
                await app.migrateDataBase<ContextEntity>();


                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseAuthorization();

                app.MapGrpcService<DoctorGrpcService>();
                app.MapControllers();
            

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
