
using doctor.application.Extenstion2;
using doctor.application.Query;
using doctor.infrastructure.Context;
using doctor.infrastructure.Extenstion;

using System.Reflection;
using DoctorandDepartmant.api.Exctention;

namespace DoctorandDepartmant.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.serviceCollection(builder.Configuration);
                builder.Services.AddMediatR(co => co.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectElementById))));

                builder.Services.ServiceColl();

                var app = builder.Build();
                app.migrateDataBase<ContextEntity>();


                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseAuthorization();


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
