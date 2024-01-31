namespace RentasArticulos.Models
{
    public class TemporalRenta
    {
        public int Renglon { get; set; }
        public int IdArticulo { get; set; }
        public string? NombreArticulo { get; set; }
        public decimal PrecioPorHora { get; set; }
        public decimal TiempoRentaMinutos { get; set; }
        public decimal SubTotal { get; set; }
    }
}
