namespace RentasArticulos.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public decimal CostoArticulo { get; set; }
        public DateTime FechaComprado { get; set; }
        public decimal PrecioPorHora { get; set; }
        public decimal PrecioPorHoraExtra { get; set; }
        public DateTime FechaUltimaRentada { get; set; }
        public int IdEstado { get; set; }
        public string? NombreEstado { get; set; }
    }
}
