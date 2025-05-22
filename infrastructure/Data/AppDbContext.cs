using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<Profesor> Profesores => Set<Profesor>();
    public DbSet<EstudianteMateria> EstudiantesMaterias => Set<EstudianteMateria>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Claves primarias
        modelBuilder.Entity<Estudiante>().HasKey(e => e.Id);
        modelBuilder.Entity<Materia>().HasKey(m => m.Id);
        modelBuilder.Entity<Profesor>().HasKey(p => p.Id);
        modelBuilder.Entity<EstudianteMateria>().HasKey(em => em.Id); // o clave compuesta si lo prefieres

        // Relación EstudianteMateria → Estudiante (muchos a uno)
        modelBuilder.Entity<EstudianteMateria>()
            .HasOne(em => em.Estudiante)
            .WithMany() // Puedes reemplazar por .WithMany(e => e.Inscripciones) si defines la colección en Estudiante
            .HasForeignKey(em => em.EstudianteId);

        // Relación EstudianteMateria → Materia (muchos a uno)
        modelBuilder.Entity<EstudianteMateria>()
            .HasOne(em => em.Materia)
            .WithMany() // Puedes reemplazar por .WithMany(m => m.EstudiantesInscritos) si defines la colección en Materia
            .HasForeignKey(em => em.MateriaId);
    }
}

