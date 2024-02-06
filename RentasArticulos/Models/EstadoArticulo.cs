using System.Data.SqlClient;
using System.Data;

namespace RentasArticulos.Models
{
    public class EstadoArticulo
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public static List<EstadoArticulo> ConsultarEstadoArticulos()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarEstadoArticulos", conx);
            command.CommandType = CommandType.StoredProcedure;
            EstadoArticulo c = new EstadoArticulo();
            List<EstadoArticulo> lista = new List<EstadoArticulo>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new EstadoArticulo();
                c.id = int.Parse(dr["Id"].ToString()!);
                c.nombre = dr["Nombre"].ToString();
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public MensajeRespuesta EjecutarAccionEstadoArticulo()
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spEjecutarAccionEstadoArticulo", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", nombre?.ToUpper().Trim());
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
        public static MensajeRespuesta BorrarEstadoArticulo(int id)
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarEstadoArticulo", conx);
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
