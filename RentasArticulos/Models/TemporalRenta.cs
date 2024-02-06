namespace RentasArticulos.Models
{
    public class TemporalRenta
    {
        public int renglon { get; set; }
        public int idArticulo { get; set; }
        public string? nombreArticulo { get; set; }
        public decimal precioPorHora { get; set; }
        public decimal tiempoRentaMinutos { get; set; }
        public decimal subTotal { get; set; }
    }
}
