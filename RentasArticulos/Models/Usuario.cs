namespace RentasArticulos.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idRol { get; set; }
        public string? nombreRol { get; set; }
        public string? correo { get; set; }
        public string? contrasena { get; set; }
    }
}
