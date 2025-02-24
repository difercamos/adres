namespace Adres.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adres.Application.Services;
using Adres.Domain.Entities;

[ApiController]
[Route("api/adquisiciones")]
public class AdquisicionesController : ControllerBase
{
    private readonly IAdquisicionService _service;
    
    public AdquisicionesController(IAdquisicionService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Adquisicion adquisicion)
    {
        _service.Agregar(adquisicion);
        return Ok(adquisicion);
    }

    [HttpGet]
    public IActionResult ObtenerTodas() => Ok(_service.ObtenerTodas());
    
    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var adquisicion = _service.ObtenerPorId(id);
        return adquisicion == null ? NotFound() : Ok(adquisicion);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Adquisicion adquisicion)
    {
        if (id != adquisicion.Id) return BadRequest();
        _service.Actualizar(adquisicion);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);
        return NoContent();
    }
}
