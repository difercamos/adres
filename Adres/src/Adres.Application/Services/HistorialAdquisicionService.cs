using Adres.Domain.Entities;
using Adres.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class HistorialAdquisicionService : IHistorialAdquisicionService
{
    private readonly AppDbContext _context;

    public HistorialAdquisicionService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<HistorialAdquisicion> ObtenerPorAdquisicion(int adquisicionId)
    {
        return _context.HistorialAdquisiciones
            .Where(h => h.AdquisicionId == adquisicionId)
            .OrderByDescending(h => h.FechaCambio)
            .ToList();
    }
}
