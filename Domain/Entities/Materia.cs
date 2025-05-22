using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Materia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int ProfesorId { get; set; }
    public int Creditos { get; set; } = 3;

    public ICollection<EstudianteMateria> EstudiantesInscritos { get; set; } = new List<EstudianteMateria>();
}
