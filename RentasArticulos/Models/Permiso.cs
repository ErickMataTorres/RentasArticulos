using System.Data.SqlClient;
using System.Data;

namespace RentasArticulos.Models
{
    public class Permiso
    {
        public int idRol { get; set; }
        public string? nombreRol { get; set; }
        public string? opciones { get; set; }

        public static List<Permiso> ConsultarPermisos()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarPermisos", conx);
            command.CommandType = CommandType.StoredProcedure;
            Permiso c = new Permiso();
            List<Permiso> lista = new List<Permiso>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new Permiso();
                c.idRol = int.Parse(dr["IdRol"].ToString()!);
                c.nombreRol = dr["NombreRol"].ToString();
                c.opciones = dr["Opcion"].ToString();
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}
