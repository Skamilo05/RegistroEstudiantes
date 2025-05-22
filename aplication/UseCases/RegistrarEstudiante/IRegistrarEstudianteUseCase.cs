using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RegistrarEstudiante;

public interface IRegistrarEstudianteUseCase
{
    Task EjecutarAsync(RegistrarEstudianteCommand comando);
}
