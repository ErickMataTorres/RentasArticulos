namespace RentasArticulos.Models
{
    public class TipoDePago
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal ComisionPorcentaje { get; set; }
    }
}
