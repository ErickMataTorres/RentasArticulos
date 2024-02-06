namespace RentasArticulos.Models
{
    public class Articulo
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public int idCategoria { get; set; }
        public string? nombreCategoria { get; set; }
        public decimal costoArticulo { get; set; }
        public DateTime fechaComprado { get; set; }
        public decimal precioPorHora { get; set; }
        public decimal precioPorHoraExtra { get; set; }
        public DateTime fechaUltimaRentada { get; set; }
        public int idEstado { get; set; }
        public string? nombreEstado { get; set; }
    }
}
