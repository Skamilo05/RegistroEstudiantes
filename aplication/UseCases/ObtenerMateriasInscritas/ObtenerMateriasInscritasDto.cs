using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ObtenerMateriasInscritas;

public class MateriaInscritaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Profesor { get; set; } = string.Empty;
    public int Creditos { get; set; }
}
