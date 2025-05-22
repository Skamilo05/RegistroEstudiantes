using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories;

public class MateriaRepository : IMateriaRepository
{
    private readonly AppDbContext _context;

    public MateriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Materia>> ObtenerTodasAsync()
    {
        return await _context.Materias.ToListAsync();
    }

    public async Task<Materia?> ObtenerPorIdAsync(int id)
    {
        return await _context.Materias.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Materia>> ObtenerMateriasPorEstudianteId(int estudianteId)
    {
        return await _context.EstudiantesMaterias
            .Where(em => em.EstudianteId == estudianteId)
            .Include(em => em.Materia)
            .Select(em => em.Materia)
            .ToListAsync();
    }
}