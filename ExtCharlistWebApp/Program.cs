using ExtCharistWebApp.Components;
using ExtCharistWebApp.Services;
using ExtCharlistWebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;

namespace ExtCharistWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var section = builder.Configuration.GetSection(nameof(ConnectionSettings));
            builder.Services.Configure<ConnectionSettings>(section);



            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
               options.LoginPath = "/login";
               options.AccessDeniedPath = "/access-denied";

            });
            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddSingleton<CookieContainer>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddScoped<ICookieService, CookieService>();
            

            //builder.WebHost.UseUrls("http://localhost:7800");

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
