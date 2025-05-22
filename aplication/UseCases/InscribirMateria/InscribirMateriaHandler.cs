using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces;
using Domain.Entities;

namespace Application.UseCases.InscribirMateria;

public class InscribirMateriaHandler : IInscribirMateriaUseCase
{
    private readonly IEstudianteRepository _estudianteRepo;
    private readonly IMateriaRepository _materiaRepo;
    private readonly IProfesorRepository _profesorRepo;

    public InscribirMateriaHandler(
        IEstudianteRepository estudianteRepo,
        IMateriaRepository materiaRepo,
        IProfesorRepository profesorRepo)
    {
        _estudianteRepo = estudianteRepo;
        _materiaRepo = materiaRepo;
        _profesorRepo = profesorRepo;
    }

    public async Task EjecutarAsync(InscribirMateriaCommand comando)
    {
        var estudiante = await _estudianteRepo.ObtenerPorIdAsync(comando.EstudianteId)
            ?? throw new Exception("Estudiante no encontrado.");

        var materia = await _materiaRepo.ObtenerPorIdAsync(comando.MateriaId)
            ?? throw new Exception("Materia no encontrada.");

        // Obtener todas las materias ya inscritas
        var materiasInscritas = await _materiaRepo.ObtenerMateriasPorEstudianteId(comando.EstudianteId);

        if (materiasInscritas.Any(m => m.Id == materia.Id))
            throw new Exception("Ya tienes esta materia inscrita.");

        if (materiasInscritas.Count >= 3)
            throw new Exception("No puedes inscribir más de 3 materias.");

        if (materiasInscritas.Any(m => m.ProfesorId == materia.ProfesorId))
            throw new Exception("Ya tienes una materia con este profesor.");

        await _estudianteRepo.InscribirMateriaAsync(comando.EstudianteId, comando.MateriaId);
    }
}
