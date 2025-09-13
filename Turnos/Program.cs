using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel para escuchar en HTTPS
// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(5079); // Para HTTP
//     options.ListenAnyIP(7160, listenOptions => listenOptions.UseHttps()); // Para HTTPS
// });

// var connectionString = builder.Configuration.GetConnectionString("TurnosContext");

// Add services to the container.
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(300);
    option.Cookie.HttpOnly = true;
});
builder.Services.AddControllersWithViews(options =>
options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
// builder.Services.AddDbContext<TurnosContext>(db => db.UseSqlServer(connectionString));
builder.Services.AddDbContext<TurnosContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TurnosContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    // pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
