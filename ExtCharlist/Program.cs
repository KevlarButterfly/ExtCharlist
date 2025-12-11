using ExtCharlist.Models;
using ExtCharlist.Services;

namespace ExtCharlist
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //ExtCharlistRepository? repository = new ExtCharlistRepository();



            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ExtCharlistDatabaseSettigs>(builder.Configuration.GetSection("ExtCharlistDatabase"));

            builder.Services.AddSingleton<CharactersService>();
            //repository.GetDataAsync();
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.AddOpenApi();

            var app = builder.Build();

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
