using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.UseCases.ObtenerCompanerosDeMateria;

public interface IObtenerCompanerosDeMateriaUseCase
{
    Task<List<Estudiante>> EjecutarAsync(int materiaId);
}
