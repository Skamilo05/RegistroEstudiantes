using Domain.Entities;

namespace Infrastructure.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Profesores.Any() || context.Materias.Any())
        {
            return; // Ya hay datos, no hacer nada
        }

        var profesores = new List<Profesor>
        {
            new() { Nombre = "Carlos Martínez" },
            new() { Nombre = "Ana Gómez" },
            new() { Nombre = "Luis Torres" },
            new() { Nombre = "Marta Ríos" },
            new() { Nombre = "Jorge Herrera" }
        };

        context.Profesores.AddRange(profesores);
        context.SaveChanges();

        var materias = new List<Materia>
        {
            new() { Nombre = "Matemáticas", ProfesorId = profesores[0].Id },
            new() { Nombre = "Estadística", ProfesorId = profesores[0].Id },
            new() { Nombre = "Física", ProfesorId = profesores[1].Id },
            new() { Nombre = "Química", ProfesorId = profesores[1].Id },
            new() { Nombre = "Programación", ProfesorId = profesores[2].Id },
            new() { Nombre = "Bases de Datos", ProfesorId = profesores[2].Id },
            new() { Nombre = "Historia", ProfesorId = profesores[3].Id },
            new() { Nombre = "Literatura", ProfesorId = profesores[3].Id },
            new() { Nombre = "Ética", ProfesorId = profesores[4].Id },
            new() { Nombre = "Filosofía", ProfesorId = profesores[4].Id }
        };

        context.Materias.AddRange(materias);
        context.SaveChanges();
    }
}
