using System.Data;
using System.Data.SqlClient;

namespace RentasArticulos.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public char administrador { get; set; }
        public static List<Rol> ConsultarRoles()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarRoles", conx);
            command.CommandType = CommandType.StoredProcedure;
            Rol c = new Rol();
            List<Rol> lista = new List<Rol>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new Rol();
                c.id = int.Parse(dr["Id"].ToString()!);
                c.nombre = dr["Nombre"].ToString();
                c.administrador = char.Parse(dr["Administrador"].ToString()!);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public MensajeRespuesta EjecutarAccionRol()
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spEjecutarAccionRol", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", nombre?.ToUpper().Trim());
            command.Parameters.AddWithValue("@Administrador", administrador);
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            try
            {
                if(dr.Read())
                {
                    mensajeRespuesta.id = int.Parse(dr["Id"].ToString()!);
                    mensajeRespuesta.nombre = dr["Nombre"].ToString();
                }
            }
            catch(Exception error)
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
        public static MensajeRespuesta BorrarRol(int id)
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarRol", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
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
