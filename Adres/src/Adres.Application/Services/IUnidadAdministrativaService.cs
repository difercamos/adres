using Adres.Domain.Entities;

public interface IUnidadAdministrativaService
{
    void Agregar(UnidadAdministrativa unidad);
    IEnumerable<UnidadAdministrativa> ObtenerTodos();
    UnidadAdministrativa? ObtenerPorId(int id);
    void Actualizar(UnidadAdministrativa unidad);
    void Eliminar(int id);
}
