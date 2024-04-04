using System.Text.Encodings.Web;
using System.Text.Unicode;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.Application.Interfaces;
using Shop.Application.Services;
using Shop.Domain.Interfaces;
using Shop.Infra.Data.Context;
using Shop.Infra.Data.Repositories;
using Shop.Infra.Ioc;
using static Shop.Infra.Ioc.DependencyContainer;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
#region context

builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

#endregion

#region authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/login";
    option.LogoutPath = "/log-out";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});

#endregion

#region Ioc

builder.Services.AddSingleton<DependencyContainer>();

builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

#endregion

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[]
    { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic, }));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


#region Ioc

void RegisterService(IServiceCollection services)
{
    DependencyContainer.RegisterService(services);
}
#endregion
