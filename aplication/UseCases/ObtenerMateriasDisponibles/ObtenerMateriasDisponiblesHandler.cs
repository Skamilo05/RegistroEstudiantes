using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.UseCases.ObtenerMateriasDisponibles;

public class ObtenerMateriasDisponiblesHandler : IObtenerMateriasDisponiblesUseCase
{
    private readonly IMateriaRepository _materiaRepo;
    private readonly IProfesorRepository _profesorRepo;

    public ObtenerMateriasDisponiblesHandler(
        IMateriaRepository materiaRepo,
        IProfesorRepository profesorRepo)
    {
        _materiaRepo = materiaRepo;
        _profesorRepo = profesorRepo;
    }

    public async Task<List<MateriaDisponibleDto>> EjecutarAsync(int estudianteId)
    {
        var todas = await _materiaRepo.ObtenerTodasAsync();
        var inscritas = await _materiaRepo.ObtenerMateriasPorEstudianteId(estudianteId);

        var materiaDtos = new List<MateriaDisponibleDto>();

        foreach (var m in todas)
        {
            var profesor = await _profesorRepo.ObtenerPorIdAsync(m.ProfesorId);

            materiaDtos.Add(new MateriaDisponibleDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Profesor = profesor?.Nombre ?? "Desconocido",
                Creditos = m.Creditos,
                Inscrita = inscritas.Any(i => i.Id == m.Id)
            });
        }

        return materiaDtos;
    }
}
