using ExtCharistWebApp.Components;
using ExtCharistWebApp.Services;
using ExtCharlistWebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

namespace ExtCharistWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var section = builder.Configuration.GetSection(nameof(APISettings));
            builder.Services.Configure<APISettings>(section);



            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
               options.LoginPath = "/login";
               options.AccessDeniedPath = "/access-denied";

            });
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<ICharacterService, CharacterService>();

            builder.WebHost.UseUrls("http://localhost:7800");

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
