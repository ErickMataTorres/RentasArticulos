namespace RentasArticulos.Models
{
    public class DetalleRenta
    {
        public int idRenta { get; set; }
        public int renglon { get; set; }
        public int idArticulo { get; set; }
        public decimal precioPorHora { get; set; }
        public decimal precioPorHoraExtra { get; set; }
        public decimal tiempoExtra { get; set; }
        public decimal cargosPorExtra { get; set; }
        public DateTime fechaRentaComenzada { get; set; }
        public DateTime fechaRentaTerminada { get; set; }
        public DateTime fechaRentaTerminadaExtra { get; set; }
        public decimal tiempoRentaMinutos { get; set; }
        public decimal subTotal { get; set; }

    }
}
