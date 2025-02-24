using Adres.Domain.Entities;
using Adres.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class AdquisicionService : IAdquisicionService
{
    private readonly AppDbContext _context;

    public AdquisicionService(AppDbContext context)
    {
        _context = context;
    }

    public void Agregar(Adquisicion adquisicion)
    {
        _context.Adquisiciones.Add(adquisicion);
        _context.SaveChanges();

        _context.HistorialAdquisiciones.Add(new HistorialAdquisicion
        {
            AdquisicionId = adquisicion.Id,
            Cambio = "Creación de adquisición",
            FechaCambio = DateTime.UtcNow
        });

        _context.SaveChanges();
    }

    public IEnumerable<Adquisicion> ObtenerTodas() => _context.Adquisiciones.Where(a => a.Activo).ToList();
    
    public Adquisicion? ObtenerPorId(int id) => _context.Adquisiciones.Find(id);
    
    public void Actualizar(Adquisicion adquisicion)
    {
        var adquisicionExistente = _context.Adquisiciones.Find(adquisicion.Id);
        if (adquisicionExistente == null)
            throw new KeyNotFoundException("La adquisición no fue encontrada.");

        _context.HistorialAdquisiciones.Add(new HistorialAdquisicion
        {
            AdquisicionId = adquisicion.Id,
            Cambio = "Modificación de adquisición",
            FechaCambio = DateTime.UtcNow
        });

        adquisicionExistente.Presupuesto = adquisicion.Presupuesto;
        adquisicionExistente.Cantidad = adquisicion.Cantidad;
        adquisicionExistente.ValorUnitario = adquisicion.ValorUnitario;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var adquisicion = _context.Adquisiciones.Find(id);
        if (adquisicion == null)
            throw new KeyNotFoundException("La adquisición no fue encontrada.");

        _context.HistorialAdquisiciones.Add(new HistorialAdquisicion
        {
            AdquisicionId = id,
            Cambio = "Adquisición eliminada",
            FechaCambio = DateTime.UtcNow
        });

        adquisicion.Activo = false;
        _context.SaveChanges();
    }
}
