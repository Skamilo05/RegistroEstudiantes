using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.LoginEstudiante;

public interface ILoginEstudianteUseCase
{
    Task<LoginEstudianteResponse> EjecutarAsync(LoginEstudianteCommand comando);
}
