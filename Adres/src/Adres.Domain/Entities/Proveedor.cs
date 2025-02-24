namespace Adres.Domain.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}
