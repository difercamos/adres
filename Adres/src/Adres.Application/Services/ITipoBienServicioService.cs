using Adres.Domain.Entities;

public interface ITipoBienServicioService
{
    void Agregar(TipoBienServicio tipo);
    IEnumerable<TipoBienServicio> ObtenerTodos();
    TipoBienServicio? ObtenerPorId(int id);
    void Actualizar(TipoBienServicio tipo);
    void Eliminar(int id);
}
