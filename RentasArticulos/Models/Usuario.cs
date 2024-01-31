namespace RentasArticulos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdRol { get; set; }
        public string? NombreRol { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
    }
}
