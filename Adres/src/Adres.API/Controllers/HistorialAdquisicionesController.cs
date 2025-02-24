namespace Adres.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Adres.Application.Services;
using Adres.Domain.Entities;

[ApiController]
[Route("api/historial-adquisiciones")]
public class HistorialAdquisicionesController : ControllerBase
{
    private readonly IHistorialAdquisicionService _service;
    
    public HistorialAdquisicionesController(IHistorialAdquisicionService service)
    {
        _service = service;
    }

    [HttpGet("{adquisicionId}")]
    public IActionResult ObtenerHistorial(int adquisicionId)
    {
        var historial = _service.ObtenerPorAdquisicion(adquisicionId);
        return Ok(historial);
    }
}
