
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;

namespace EvoPlanet.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200","http://localhost:7081").AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICelestialBodyService,CelestialBodyMongoService>();
            builder.Services.AddSingleton<ISolarSystemService, SolarSystemMongoService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddCors();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            /*
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
            });
            */
            //UseCors must be placed after "UseRouting", but before "UseAuthorization"
            /*
            app.UseCors(
                options =>
                {
                    // options.WithOrigins(https://localhost:7081);
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }
            );              
            */

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();


            app.MapFallbackToFile("/index.html");
            app.Run();
        }
    }
}
