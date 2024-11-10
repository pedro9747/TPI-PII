using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TorneoApi.Models;
using TorneoBack.Repository;
using TorneoBack.Repository.Contracts;
using TorneoBack.Service;
using TorneoBack.Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Configurar JWT Bearer

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ArbitroOnly", policy => policy.RequireRole("Arbitro"));
    options.AddPolicy("JugadorOnly", policy => policy.RequireRole("Jugador"));
});


// Agregar servicios al contenedor.
builder.Services.AddControllers();
// Configuración de Swagger para desarrollo.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de la base de datos.
builder.Services.AddDbContext<TorneoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de repositorios y servicios.
builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();
builder.Services.AddScoped<ITorneoRepository, TorneoRepository>();
builder.Services.AddScoped<IEquiposRepository, EquiposRepository>();
builder.Services.AddScoped<ITorneoService, TorneoService>();
builder.Services.AddScoped<IAuthService, AuthService>();




// Configuración de CORS para permitir todos los orígenes, métodos y encabezados.
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configuración del pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política CORS que permite cualquier origen.
app.UseCors("PermitirTodo");

// Usar la autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
