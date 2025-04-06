using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Presentacion.Data;
using Presentacion.Components;
using Presentacion.Components.Account;

using Datos.Contexto;
using Datos.Repositorios;
using Datos.IRepositorios;

using Negocios;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
      options.DefaultScheme = IdentityConstants.ApplicationScheme;
      options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

/*********************************************************************************************************
*                     Servicios agregados para el proyecto                                               *
*********************************************************************************************************/

//CONTEXTOS

// Configuracion de la conexion
var connectionString = builder.Configuration.GetConnectionString("ConexionBD")
  ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Contexto para la gestion de usuarios creado para las cuentas individuales
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Contexto de base de datos (ContextoBD) configurada en la capa de datos
builder.Services.AddDbContext<D_ContextoBD>(options => options.UseSqlServer(connectionString));

// Registro del repositorios de carreras
builder.Services.AddScoped<ICarreraRepositorio, CarreraRepositorio>();

// Inyección de dependencias para la capa de datos y servicios
// Carreras
builder.Services.AddScoped<CarreraRepositorio>();
builder.Services.AddScoped<CarreraNegocios>();
builder.Services.AddScoped<CarreraServicios>();
// Materias
builder.Services.AddScoped<MateriaServicios>();
builder.Services.AddScoped<MateriasNegocios>();
builder.Services.AddScoped<MateriaRepositorio>();

builder.Services.AddScoped<ToasterServicio>();
builder.Services.AddScoped<SweetAlertServicio>();
/***********************************************************************************************************/


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
