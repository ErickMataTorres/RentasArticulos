using System.Data.SqlClient;
using System.Data;

namespace RentasArticulos.Models
{
    public class TipoDePago
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal comisionPorcentaje { get; set; }
        public static List<TipoDePago> ConsultarTipoDePagos()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarTipoDePagos", conx);
            command.CommandType = CommandType.StoredProcedure;
            TipoDePago c = new TipoDePago();
            List<TipoDePago> lista = new List<TipoDePago>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = new TipoDePago();
                c.id = int.Parse(dr["Id"].ToString()!);
                c.nombre = dr["Nombre"].ToString();
                c.comisionPorcentaje = decimal.Parse(dr["ComisionPorcentaje"].ToString()!);
                lista.Add(c);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public MensajeRespuesta EjecutarAccionTipoDePago()
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spEjecutarAccionTipoDePago", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nombre", nombre?.ToUpper().Trim());
            command.Parameters.AddWithValue("@ComisionPorcentaje", comisionPorcentaje);
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
        public static MensajeRespuesta BorrarTipoDePago(int id)
        {
            Models.MensajeRespuesta mensajeRespuesta = new Models.MensajeRespuesta();
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spBorrarTipoDePago", conx);
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
