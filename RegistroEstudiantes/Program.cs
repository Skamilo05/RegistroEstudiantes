using Application.UseCases.InscribirMateria;
using Application.UseCases.LoginEstudiante;
using Application.UseCases.RegistrarEstudiante;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.UseCases.ObtenerMateriasInscritas;
using Application.UseCases.ObtenerCompanerosDeMateria;
using Application.UseCases.ObtenerResumenEstudiante;
using Application.UseCases.ObtenerMateriasDisponibles;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Casos de uso
builder.Services.AddScoped<IRegistrarEstudianteUseCase, RegistrarEstudianteHandler>();
builder.Services.AddScoped<ILoginEstudianteUseCase, LoginEstudianteHandler>();
builder.Services.AddScoped<IInscribirMateriaUseCase, InscribirMateriaHandler>();
builder.Services.AddScoped<IObtenerMateriasInscritasUseCase, ObtenerMateriasInscritasHandler>();
builder.Services.AddScoped<IObtenerCompanerosDeMateriaUseCase, ObtenerCompanerosDeMateriaHandler>();
builder.Services.AddScoped<IObtenerResumenEstudianteUseCase, ObtenerResumenEstudianteHandler>();
builder.Services.AddScoped<IObtenerMateriasDisponiblesUseCase, ObtenerMateriasDisponiblesHandler>();

// Repositorios
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Dominio del frontend
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
    });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Inicializador de base de datos
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(db); 
}


app.Run();
