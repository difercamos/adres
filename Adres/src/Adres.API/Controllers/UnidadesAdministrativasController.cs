namespace Adres.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adres.Application.Services;
using Adres.Domain.Entities;

[ApiController]
[Route("api/unidadesadministrativas")]
public class UnidadesAdministrativasController : ControllerBase
{
    private readonly IUnidadAdministrativaService _service;
    
    public UnidadesAdministrativasController(IUnidadAdministrativaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] UnidadAdministrativa unidad)
    {
        _service.Agregar(unidad);
        return Ok(unidad);
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var unidad = _service.ObtenerPorId(id);
        return unidad == null ? NotFound() : Ok(unidad);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] UnidadAdministrativa unidad)
    {
        if (id != unidad.Id) return BadRequest();
        _service.Actualizar(unidad);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);
        return NoContent();
    }
}