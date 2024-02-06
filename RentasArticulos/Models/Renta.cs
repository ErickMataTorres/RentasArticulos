namespace RentasArticulos.Models
{
    public class Renta
    {
        public int id { get; set; }
        public int idPago { get; set; }
        public string? nombrePago { get; set; }
        public DateTime fecha { get; set; }
        public decimal comisionPorcentaje{ get; set; }
        public decimal comision { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }
        public decimal dineroPago { get; set; }
        public decimal cambio { get; set; }
    }
}
