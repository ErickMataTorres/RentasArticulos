using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RentasArticulos.Models
{
    public class Permiso
    {
        public int idRol { get; set; }
        public string? nombreRol { get; set; }
        public string? opciones { get; set; }

        public static Permiso ConsultarPermisosPorIdRol(int idRol)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarPermisosPorIdRol", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdRol", idRol);
            Permiso c = new Permiso();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                c.idRol = int.Parse(dr["IdRol"].ToString()!);
                //c.nombreRol = dr["NombreRol"].ToString();
                c.opciones = dr["Opciones"].ToString();
            }
            dr.Close();
            conx.Close();
            return c;
        }
        public MensajeRespuesta GuardarPermisos()
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spGuardarPermisos", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdRol", idRol);
            command.Parameters.AddWithValue("@Opciones", opciones);
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    mensajeRespuesta.id = int.Parse(dr["Id"].ToString()!);
                    mensajeRespuesta.nombre = dr["Nombre"].ToString();
                }
            }
            catch (Exception error)
            {
                mensajeRespuesta.nombre = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    dr.Close();
                    conx.Close();
                }
            }
            dr.Close();
            conx.Close();
            return mensajeRespuesta;
        }
    }
}
