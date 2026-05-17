
using Azure;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // builder.Services.AddSwaggerForOcelot(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
          
           // builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger UI (Gateway only - optional)
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gateway API");
                //});
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints
                (end=>end.MapGet("/",async context => { context.Response.WriteAsync("hello"); } ));


            await app.UseOcelot();

            await app.RunAsync();
        }
    }

}