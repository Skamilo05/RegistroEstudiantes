using Microsoft.AspNetCore.Mvc;
using Application.UseCases.ObtenerCompanerosDeMateria;

namespace RegistroEstudiantes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriasController : ControllerBase
{
    private readonly IObtenerCompanerosDeMateriaUseCase _useCase;

    public MateriasController(IObtenerCompanerosDeMateriaUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet("{materiaId}/companeros")]
    public async Task<IActionResult> ObtenerCompaneros(int materiaId)
    {
        try
        {
            var estudiantes = await _useCase.EjecutarAsync(materiaId);
            return Ok(estudiantes);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
