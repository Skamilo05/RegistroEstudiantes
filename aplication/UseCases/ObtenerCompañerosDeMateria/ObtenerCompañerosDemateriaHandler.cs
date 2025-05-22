using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.ObtenerCompanerosDeMateria;

public class ObtenerCompanerosDeMateriaHandler : IObtenerCompanerosDeMateriaUseCase
{
    private readonly IEstudianteRepository _repo;

    public ObtenerCompanerosDeMateriaHandler(IEstudianteRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Estudiante>> EjecutarAsync(int materiaId)
    {
        return await _repo.ObtenerCompañerosDeMateriaAsync(materiaId);
    }
}
