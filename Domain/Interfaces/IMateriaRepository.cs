using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces;


public interface IMateriaRepository
{
    Task<List<Materia>> ObtenerTodasAsync();
    Task<Materia?> ObtenerPorIdAsync(int id);

    Task<List<Materia>> ObtenerMateriasPorEstudianteId(int estudianteId);
}
