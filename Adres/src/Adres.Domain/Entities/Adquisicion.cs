namespace Adres.Domain.Entities
{
    public class Adquisicion
    {
        public int Id { get; set; }
        public required string Presupuesto { get; set; }
        public int UnidadAdministrativaId { get; set; }
        public int TipoBienServicioId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public int ProveedorId { get; set; }
        public required string Documentacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
