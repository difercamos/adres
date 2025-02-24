namespace Adres.Domain.Entities;

public class HistorialAdquisicion
{
    public int Id { get; set; }
    public int AdquisicionId { get; set; }
    public string Cambio { get; set; } = string.Empty;
    public DateTime FechaCambio { get; set; } = DateTime.UtcNow;
}
