using System.Data;
using System.Data.SqlClient;

namespace RentasArticulos.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public char Administrador { get; set; }
        public static List<Rol> ConsultarRoles()
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spConsultarRoles", conx);
            command.CommandType = CommandType.StoredProcedure;
            Rol r = new Rol();
            List<Rol> lista = new List<Rol>();
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                r = new Rol();
                r.Id = int.Parse(dr["Id"].ToString()!);
                r.Nombre = dr["Nombre"].ToString();
                r.Administrador = char.Parse(dr["Administrador"].ToString()!);
                lista.Add(r);
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
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Nombre", Nombre?.ToUpper().Trim());
            command.Parameters.AddWithValue("@Administrador", Administrador);
            conx.Open();
            SqlDataReader dr = command.ExecuteReader();
            try
            {
                if(dr.Read())
                {
                    mensajeRespuesta.Id = int.Parse(dr["Id"].ToString()!);
                    mensajeRespuesta.Nombre = dr["Nombre"].ToString();
                }
            }
            catch(Exception error)
            {
                mensajeRespuesta.Nombre = error.Message;
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
