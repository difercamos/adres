using Adres.Domain.Entities;

public interface IProveedorService
{
    void Agregar(Proveedor proveedor);
    IEnumerable<Proveedor> ObtenerTodos();
    Proveedor? ObtenerPorId(int id);
    void Actualizar(Proveedor proveedor);
    void Eliminar(int id);
}
