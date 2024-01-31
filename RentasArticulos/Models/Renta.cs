namespace RentasArticulos.Models
{
    public class Renta
    {
        public int Id { get; set; }
        public int IdPago { get; set; }
        public string? NombrePago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ComisionPorcentaje{ get; set; }
        public decimal Comision { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal DineroPago { get; set; }
        public decimal Cambio { get; set; }
    }
}
