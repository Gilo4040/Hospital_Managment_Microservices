
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
            builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json",optional:true, reloadOnChange:true);
            builder.Services.AddOcelot(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               // app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseEndpoints(o=>o.Map("/", async c => { c.Response.WriteAsync("hello"); } ));
             await app.UseOcelot();    
             await app.RunAsync();
        }
    }
}
