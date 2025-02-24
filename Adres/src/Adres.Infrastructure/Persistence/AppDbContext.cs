using Microsoft.EntityFrameworkCore;
using Adres.Domain.Entities;

namespace Adres.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Adquisicion> Adquisiciones { get; set; }
    public DbSet<UnidadAdministrativa> UnidadesAdministrativas { get; set; }
    public DbSet<TipoBienServicio> TiposBienesServicios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<HistorialAdquisicion> HistorialAdquisiciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
