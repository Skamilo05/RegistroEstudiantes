using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces;

public interface IEstudianteRepository
{
    Task<Estudiante?> ObtenerPorIdAsync(int id);
    Task<Estudiante?> ObtenerPorCorreoAsync(string correo);
    Task CrearAsync(Estudiante estudiante);
    Task InscribirMateriaAsync(int estudianteId, int materiaId);
    Task<List<Estudiante>> ObtenerCompañerosDeMateriaAsync(int materiaId);

    
}



