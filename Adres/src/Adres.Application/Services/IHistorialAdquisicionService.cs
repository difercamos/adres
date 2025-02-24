using Adres.Domain.Entities;

public interface IHistorialAdquisicionService
{
    IEnumerable<HistorialAdquisicion> ObtenerPorAdquisicion(int adquisicionId);
}
