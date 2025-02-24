namespace Adres.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adres.Application.Services;
using Adres.Domain.Entities;

[ApiController]
[Route("api/tiposbienes")]
public class TiposBienesServiciosController : ControllerBase
{
    private readonly ITipoBienServicioService _service;
    
    public TiposBienesServiciosController(ITipoBienServicioService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] TipoBienServicio tipo)
    {
        _service.Agregar(tipo);
        return Ok(tipo);
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var tipo = _service.ObtenerPorId(id);
        return tipo == null ? NotFound() : Ok(tipo);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] TipoBienServicio tipo)
    {
        if (id != tipo.Id) return BadRequest();
        _service.Actualizar(tipo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);
        return NoContent();
    }
}