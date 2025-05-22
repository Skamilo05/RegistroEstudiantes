using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.RegistrarEstudiante;

public class RegistrarEstudianteHandler : IRegistrarEstudianteUseCase
{
    private readonly IEstudianteRepository _repositorio;

    public RegistrarEstudianteHandler(IEstudianteRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task EjecutarAsync(RegistrarEstudianteCommand comando)
    {
        var estudianteExistente = await _repositorio.ObtenerPorCorreoAsync(comando.Correo);
        if (estudianteExistente != null)
        {
            throw new Exception("Ya existe un estudiante con ese correo.");
        }

        var nuevoEstudiante = new Estudiante
        {
            Nombre = comando.Nombre,
            Correo = comando.Correo,
            Contrasena = comando.Contrasena // Aquí deberías encriptar en la vida real
        };

        await _repositorio.CrearAsync(nuevoEstudiante);
    }
}
