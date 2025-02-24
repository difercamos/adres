using Adres.Domain.Entities;

public interface IAdquisicionService
{
    void Agregar(Adquisicion adquisicion);
    IEnumerable<Adquisicion> ObtenerTodas();
    Adquisicion? ObtenerPorId(int id);
    void Actualizar(Adquisicion adquisicion);
    void Eliminar(int id);
}
