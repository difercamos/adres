namespace Adres.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adres.Application.Services;
using Adres.Domain.Entities;

[ApiController]
[Route("api/proveedores")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorService _service;
    
    public ProveedoresController(IProveedorService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Proveedor proveedor)
    {
        _service.Agregar(proveedor);
        return Ok(proveedor);
    }

    [HttpGet]
    public IActionResult ObtenerTodos() => Ok(_service.ObtenerTodos());
    
    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var proveedor = _service.ObtenerPorId(id);
        return proveedor == null ? NotFound() : Ok(proveedor);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Proveedor proveedor)
    {
        if (id != proveedor.Id) return BadRequest();
        _service.Actualizar(proveedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);
        return NoContent();
    }
}