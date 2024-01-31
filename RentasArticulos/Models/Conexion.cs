using System.Data.SqlClient;

namespace RentasArticulos.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            string conx = "DATA SOURCE = A; INITIAL CATALOG = RentasArticulosBD; INTEGRATED SECURITY = YES;";
            SqlConnection s = new SqlConnection(conx);
            return s;
        }
    }
}
