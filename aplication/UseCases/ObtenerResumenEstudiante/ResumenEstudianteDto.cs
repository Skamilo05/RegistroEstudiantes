using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.UseCases.ObtenerResumenEstudiante;

public class ResumenEstudianteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public List<MateriaResumenDto> Materias { get; set; } = new();
    public int TotalCreditos => Materias.Sum(m => m.Creditos);
}

public class MateriaResumenDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Profesor { get; set; } = string.Empty;
    public int Creditos { get; set; }
}
