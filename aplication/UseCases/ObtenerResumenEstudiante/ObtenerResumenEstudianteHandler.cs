using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.UseCases.ObtenerResumenEstudiante;

namespace Application.UseCases.ObtenerResumenEstudiante;

public class ObtenerResumenEstudianteHandler : IObtenerResumenEstudianteUseCase
{
    private readonly IEstudianteRepository _estudianteRepo;
    private readonly IMateriaRepository _materiaRepo;
    private readonly IProfesorRepository _profesorRepo;

    public ObtenerResumenEstudianteHandler(
        IEstudianteRepository estudianteRepo,
        IMateriaRepository materiaRepo,
        IProfesorRepository profesorRepo)
    {
        _estudianteRepo = estudianteRepo;
        _materiaRepo = materiaRepo;
        _profesorRepo = profesorRepo;
    }

    public async Task<ResumenEstudianteDto> EjecutarAsync(int estudianteId)
    {
        var estudiante = await _estudianteRepo.ObtenerPorIdAsync(estudianteId)
            ?? throw new Exception("Estudiante no encontrado.");

        var materias = await _materiaRepo.ObtenerMateriasPorEstudianteId(estudianteId);

        var materiaDtos = materias.Select(m => new MateriaResumenDto
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Profesor = _profesorRepo.ObtenerPorIdAsync(m.ProfesorId).Result?.Nombre ?? "Desconocido",
            Creditos = m.Creditos
        }).ToList();

        return new ResumenEstudianteDto
        {
            Id = estudiante.Id,
            Nombre = estudiante.Nombre,
            Correo = estudiante.Correo,
            Materias = materiaDtos
        };
    }
}
