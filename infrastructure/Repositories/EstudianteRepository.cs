using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EstudianteRepository : IEstudianteRepository
{
    private readonly AppDbContext _context;

    public EstudianteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Estudiante?> ObtenerPorIdAsync(int id)
    {
        return await _context.Estudiantes.FindAsync(id);
    }

    public async Task<Estudiante?> ObtenerPorCorreoAsync(string correo)
    {
        return await _context.Estudiantes.FirstOrDefaultAsync(e => e.Correo == correo);
    }

    public async Task CrearAsync(Estudiante estudiante)
    {
        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync();
    }

    public async Task InscribirMateriaAsync(int estudianteId, int materiaId)
    {
        var relacion = new EstudianteMateria
        {
            EstudianteId = estudianteId,
            MateriaId = materiaId
        };

        _context.EstudiantesMaterias.Add(relacion);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Estudiante>> ObtenerCompañerosDeMateriaAsync(int materiaId)
    {
        return await _context.EstudiantesMaterias
            .Where(em => em.MateriaId == materiaId)
            .Include(em => em.Estudiante)
            .Select(em => em.Estudiante)
            .ToListAsync();
    }
}
