using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProfesorRepository : IProfesorRepository
{
    private readonly AppDbContext _context;

    public ProfesorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Profesor?> ObtenerPorIdAsync(int id)
    {
        return await _context.Profesores.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Profesor>> ObtenerTodosAsync()
    {
        return await _context.Profesores.ToListAsync();
    }
}
