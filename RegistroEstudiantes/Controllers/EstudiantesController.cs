using Application.UseCases.InscribirMateria;
using Application.UseCases.LoginEstudiante;
using Application.UseCases.ObtenerMateriasInscritas;
using Application.UseCases.ObtenerResumenEstudiante;
using Application.UseCases.RegistrarEstudiante;
using Microsoft.AspNetCore.Mvc;


namespace RegistroEstudiantes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IRegistrarEstudianteUseCase _registrarUseCase;
    private readonly ILoginEstudianteUseCase _loginUseCase;
    private readonly IInscribirMateriaUseCase _inscribirUseCase;
    private readonly IObtenerMateriasInscritasUseCase _obtenerMateriasUseCase;
    private readonly IObtenerResumenEstudianteUseCase _resumenUseCase;
    private readonly IObtenerMateriasDisponiblesUseCase _materiasDisponiblesUseCase;

    public EstudiantesController(
        IRegistrarEstudianteUseCase registrarUseCase,
        ILoginEstudianteUseCase loginUseCase,
        IInscribirMateriaUseCase inscribirUseCase,
        IObtenerMateriasInscritasUseCase obtenerMateriasUseCase,
        IObtenerResumenEstudianteUseCase resumenUseCase,
        IObtenerMateriasDisponiblesUseCase materiasDisponiblesUseCase)
    {
        _registrarUseCase = registrarUseCase;
        _loginUseCase = loginUseCase;
        _inscribirUseCase = inscribirUseCase;
        _obtenerMateriasUseCase = obtenerMateriasUseCase;
        _resumenUseCase = resumenUseCase;
        _materiasDisponiblesUseCase = materiasDisponiblesUseCase;
    }


    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] RegistrarEstudianteCommand comando)
    {
        try
        {
            await _registrarUseCase.EjecutarAsync(comando);
            return Ok(new { mensaje = "Estudiante registrado exitosamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginEstudianteCommand comando)
    {
        try
        {
            var result = await _loginUseCase.EjecutarAsync(comando);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }


    [HttpPost("inscribir")]
    public async Task<IActionResult> Inscribir([FromBody] InscribirMateriaCommand comando)
    {
        try
        {
            await _inscribirUseCase.EjecutarAsync(comando);
            return Ok(new { mensaje = "Materia inscrita correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpGet("{id}/materias")]
    public async Task<IActionResult> ObtenerMaterias(int id)
    {
        try
        {
            var materias = await _obtenerMateriasUseCase.EjecutarAsync(id);
            return Ok(materias);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }

    }
    [HttpGet("{id}/resumen")]
    public async Task<IActionResult> ObtenerResumen(int id)
    {
        try
        {
            var resumen = await _resumenUseCase.EjecutarAsync(id);
            return Ok(resumen);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }


    [HttpGet("{id}/materias-disponibles")]
    public async Task<IActionResult> ObtenerMateriasDisponibles(int id)
    {
        try
        {
            var materias = await _materiasDisponiblesUseCase.EjecutarAsync(id);
            return Ok(materias);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}