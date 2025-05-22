using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RegistrarEstudiante;

public class RegistrarEstudianteCommand
{
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
}
