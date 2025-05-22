using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InscribirMateria;

public class InscribirMateriaCommand
{
    public int EstudianteId { get; set; }
    public int MateriaId { get; set; }
}
