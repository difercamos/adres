using Adres.Domain.Entities;
using Adres.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class ProveedorService : IProveedorService
{
    private readonly AppDbContext _context;

    public ProveedorService(AppDbContext context)
    {
        _context = context;
    }

    public void Agregar(Proveedor proveedor)
    {
        _context.Proveedores.Add(proveedor);
        _context.SaveChanges();
    }

    public IEnumerable<Proveedor> ObtenerTodos() => _context.Proveedores.Where(a => a.Activo).ToList();

    public Proveedor? ObtenerPorId(int id) => _context.Proveedores.Find(id);

    public void Actualizar(Proveedor proveedor)
    {
        var proveedorExistente = _context.Proveedores.Find(proveedor.Id);
        if (proveedorExistente == null)
            throw new KeyNotFoundException("El proveedor no fue encontrado.");

        proveedorExistente.Nombre = proveedor.Nombre;
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var proveedor = _context.Proveedores.Find(id);
        if (proveedor == null)
            throw new KeyNotFoundException("El proveedor no fue encontrado.");

        proveedor.Activo = false; // Eliminación lógica
        _context.SaveChanges();
    }
}
