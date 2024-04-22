using System.Data.SqlClient;
using System.Data;

namespace RentasArticulos.Models
{
    public class TipoDeVenta
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public static List<TipoDeVenta> ConsultarTipoDeVentas()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarTipoDeVentas", conx);
            command.CommandType = CommandType.StoredProcedure;
            TipoDeVenta c = new TipoDeVenta();
            List<TipoDeVenta> lista = new List<TipoDeVenta>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new TipoDeVenta();
                c.id = int.Parse(dr["Id"].ToString()!);
                c.nombre = dr["Nombre"].ToString();
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }

        public MensajeRespuesta EjecutarAccionTipoDeVenta()
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spEjecutarAccionTipoDeVenta", conx);
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
        public static MensajeRespuesta BorrarTipoDeVenta(int id)
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarTipoDeVenta", conx);
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
