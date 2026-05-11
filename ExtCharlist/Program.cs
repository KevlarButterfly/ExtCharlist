using ExtCharlistAPI.Services;
using ExtCharlistLibrary.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExtCharlistAPI
{
    public class Program
    {
        private static IOptions<ExtCharlistDatabaseSettigs> settings;

        public static void Main(string[] args)
        {
            //ExtCharlistRepository? repository = new ExtCharlistRepository();

            var builder = WebApplication.CreateBuilder(args);

            //object config = builder.Configuration.GetSection("ExtDnDCharlistStore")

            //settings = config.Bind();

            
            
            builder.Services.Configure<ExtCharlistDatabaseSettigs>(builder.Configuration.GetSection("ExtDnDCharlistStore"));

            builder.Services.AddSingleton<CharactersService>();
            builder.Services.AddSingleton<CharacterRaceService>();
            builder.Services.AddSingleton<UsersService>();
            builder.Services.AddSingleton<PasswordHashService>();
            builder.Services.AddSingleton<Mapper>();
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/access-denied";

            });
            //repository.GetDataAsync();
            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.AddOpenApi();
            
            var sp = builder.Services.BuildServiceProvider();

            var charRaceService = sp.GetService<CharacterRaceService>();

            var charService = sp.GetService<CharactersService>();

            var app = builder.Build();

            app.Map("/admin", [Authorize(Roles = "admin")] () => "Admin Panel");
            ExtCharlistRepository? repository = new ExtCharlistRepository(charRaceService, charService);


            //repository.WriteAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseDeveloperExceptionPage();
            }

            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Run();
            
            

        }
        
    }
}
