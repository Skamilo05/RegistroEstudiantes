using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.ObtenerMateriasInscritas;

public class ObtenerMateriasInscritasHandler : IObtenerMateriasInscritasUseCase
{
    private readonly IMateriaRepository _materiaRepo;
    private readonly IProfesorRepository _profesorRepo;

    public ObtenerMateriasInscritasHandler(IMateriaRepository materiaRepo, IProfesorRepository profesorRepo)
    {
        _materiaRepo = materiaRepo;
        _profesorRepo = profesorRepo;
    }

    public async Task<List<MateriaInscritaDto>> EjecutarAsync(int estudianteId)
    {
        var materias = await _materiaRepo.ObtenerMateriasPorEstudianteId(estudianteId);
        var materiaDtos = new List<MateriaInscritaDto>();

        foreach (var m in materias)
        {
            var profesor = await _profesorRepo.ObtenerPorIdAsync(m.ProfesorId);

            materiaDtos.Add(new MateriaInscritaDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Profesor = profesor?.Nombre ?? "Desconocido",
                Creditos = m.Creditos
            });
        }


        return materiaDtos;
    }
}