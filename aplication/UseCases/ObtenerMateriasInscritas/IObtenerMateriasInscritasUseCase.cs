using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.UseCases.ObtenerMateriasInscritas;

public interface IObtenerMateriasInscritasUseCase
{
    Task<List<MateriaInscritaDto>> EjecutarAsync(int estudianteId);
}