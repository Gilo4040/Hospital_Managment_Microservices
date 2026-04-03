
using Patient.Api.extien;
using Patient.Application.Exetiention;
using Patient.Application.Query;
using Patient.Infrastructure.ContextFolder;
using Patient.Infrastructure.Exetientation2;
using System.Reflection;

namespace Patient.Api
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
            builder.Services.AddMediatR(co => co.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(SelectListOfPatient))));
            builder.Services.AddExte();
            builder.Services.AddSeti(builder.Configuration);
           
            var app = builder.Build();
            app.migrateDataBase<Contextpatient>();
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
