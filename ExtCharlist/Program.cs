using ExtCharlist.Models;
using ExtCharlist.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExtCharlist
{
    public class Program
    {
        private static IOptions<ExtCharlistDatabaseSettigs> settigs;

        public static void Main(string[] args)
        {
            //ExtCharlistRepository? repository = new ExtCharlistRepository();

            var builder = WebApplication.CreateBuilder(args);

            //object config = builder.Configuration.GetSection("ExtDnDCharlistStore")

            //settings = config.Bind();

            ExtCharlistRepository? repository = new ExtCharlistRepository();

            builder.Services.Configure<ExtCharlistDatabaseSettigs>(builder.Configuration.GetSection("ExtDnDCharlistStore"));

            builder.Services.AddSingleton<CharactersService>();
            builder.Services.AddSingleton<CharacterRaceService>();
            //repository.GetDataAsync();
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.AddOpenApi();
            
            var sp = builder.Services.BuildServiceProvider();

            var charRaceService = sp.GetService<CharacterRaceService>();

            var app = builder.Build();

            

            repository.WriteAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Run();
            
            

        }
        
    }
}
