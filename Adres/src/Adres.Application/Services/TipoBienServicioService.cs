using Adres.Domain.Entities;
using Adres.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class TipoBienServicioService : ITipoBienServicioService
{
    private readonly AppDbContext _context;

    public TipoBienServicioService(AppDbContext context)
    {
        _context = context;
    }

    public void Agregar(TipoBienServicio tipo)
    {
        _context.TiposBienesServicios.Add(tipo);
        _context.SaveChanges();
    }

    public IEnumerable<TipoBienServicio> ObtenerTodos() => _context.TiposBienesServicios.Where(a => a.Activo).ToList();
    
    public TipoBienServicio? ObtenerPorId(int id) => _context.TiposBienesServicios.Find(id);
    
    public void Actualizar(TipoBienServicio tipo)
    {
        var tipoExistente = _context.TiposBienesServicios.Find(tipo.Id);
        if (tipoExistente == null)
            throw new KeyNotFoundException("El tipo no fue encontrado.");

        tipoExistente.Descripcion = tipo.Descripcion;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var tipo = _context.TiposBienesServicios.Find(id);
        if (tipo == null)
            throw new KeyNotFoundException("El tipo no fue encontrado.");

        tipo.Activo = false;
        _context.SaveChanges();
    }
}
