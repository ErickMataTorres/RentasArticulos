namespace RentasArticulos.Models
{
    public class DetalleRenta
    {
        public int IdRenta { get; set; }
        public int Renglon { get; set; }
        public int IdArticulo { get; set; }
        public decimal PrecioPorHora { get; set; }
        public decimal PrecioPorHoraExtra { get; set; }
        public decimal TiempoExtra { get; set; }
        public decimal CargosPorExtra { get; set; }
        public DateTime FechaRentaComenzada { get; set; }
        public DateTime FechaRentaTerminada { get; set; }
        public DateTime FechaRentaTerminadaExtra { get; set; }
        public decimal TiempoRentaMinutos { get; set; }
        public decimal SubTotal { get; set; }

    }
}
