using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces;

public interface IProfesorRepository
{
    Task<Profesor?> ObtenerPorIdAsync(int id);
    Task<List<Profesor>> ObtenerTodosAsync();
}