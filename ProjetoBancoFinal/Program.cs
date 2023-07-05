using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoBancoFinal.Areas.Identity.Data;
using ProjetoBancoFinal.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BancoXPTOContextConnection") ?? throw new InvalidOperationException("Connection string 'BancoXPTOContextConnection' not found.");

builder.Services.AddDbContext<BancoXPTOContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Cliente>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<BancoXPTOContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Injeção de depêndencia
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IChavePixRepository, ChavePixRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
