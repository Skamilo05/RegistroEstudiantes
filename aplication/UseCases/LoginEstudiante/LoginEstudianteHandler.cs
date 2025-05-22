using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interfaces;
using Application.DTOs;
using Domain;

namespace Application.UseCases.LoginEstudiante;

public class LoginEstudianteHandler : ILoginEstudianteUseCase
{
    private readonly IEstudianteRepository _repo;

    public LoginEstudianteHandler(IEstudianteRepository repo)
    {
        _repo = repo;
    }

    public async Task<LoginEstudianteResponse> EjecutarAsync(LoginEstudianteCommand comando)
    {
        var estudiante = await _repo.ObtenerPorCorreoAsync(comando.Correo);
        if (estudiante == null || estudiante.Contrasena != comando.Contrasena)
        {
            throw new Exception(Mensajes.CredencialesInvalidas);
        }

        return new LoginEstudianteResponse
        {
            Id = estudiante.Id,
            Nombre = estudiante.Nombre,
            Correo = estudiante.Correo
        };
    }
}
