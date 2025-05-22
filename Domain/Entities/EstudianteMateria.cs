using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class EstudianteMateria
{
    public int Id { get; set; }

    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; } = null!;

    public int MateriaId { get; set; }
    public Materia Materia { get; set; } = null!;
}
