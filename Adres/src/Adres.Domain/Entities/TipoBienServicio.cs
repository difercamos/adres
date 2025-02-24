namespace Adres.Domain.Entities
{
    public class TipoBienServicio
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
