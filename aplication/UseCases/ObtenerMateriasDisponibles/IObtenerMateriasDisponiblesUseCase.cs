using Application.UseCases.ObtenerMateriasDisponibles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IObtenerMateriasDisponiblesUseCase
{
    Task<List<MateriaDisponibleDto>> EjecutarAsync(int estudianteId);
}