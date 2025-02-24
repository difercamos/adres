namespace Adres.Application.Services;
using Adres.Domain.Entities;
using Adres.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class UnidadAdministrativaService : IUnidadAdministrativaService
{
    private readonly AppDbContext _context;

    public UnidadAdministrativaService(AppDbContext context)
    {
        _context = context;
    }

    public void Agregar(UnidadAdministrativa unidad)
    {
        _context.UnidadesAdministrativas.Add(unidad);
        _context.SaveChanges();
    }

    public IEnumerable<UnidadAdministrativa> ObtenerTodos() => _context.UnidadesAdministrativas.Where(a => a.Activo).ToList();
    
    public UnidadAdministrativa? ObtenerPorId(int id) => _context.UnidadesAdministrativas.Find(id);
    
    public void Actualizar(UnidadAdministrativa unidad)
    {
        var unidadExistente = _context.UnidadesAdministrativas.Find(unidad.Id);
        if (unidadExistente == null)
            throw new KeyNotFoundException("La unidad no fue encontrada.");

        unidadExistente.Nombre = unidad.Nombre;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var unidad = _context.UnidadesAdministrativas.Find(id);
        if (unidad == null)
            throw new KeyNotFoundException("La unidad no fue encontrada.");

        unidad.Activo = false;
        _context.SaveChanges();
    }
}
