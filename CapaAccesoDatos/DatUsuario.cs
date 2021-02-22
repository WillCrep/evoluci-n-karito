using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class DatUsuario
    {
        #region singleton
        private static readonly DatUsuario instancia = new DatUsuario();
        public static DatUsuario Instancia
        {
            get
            {
                return DatUsuario.instancia;
            }
        }
        #endregion singleton

        #region metodos
        public Boolean InsertarUsuario(EntUsuario usuario)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                //@prmstrNombresPersona, @prmstrApellidosPersona , @prmdatetimeFecNacPersona , @prmstrDireccionPersona, @prmstrCelularPersona, @prmstrDniPersona
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombresPersona", usuario.persona.NombresPersona);
                cmd.Parameters.AddWithValue("@prmstrApellidosPersona", usuario.persona.ApellidosPersona);
                cmd.Parameters.AddWithValue("@prmdatetimeFecNacPersona", usuario.persona.FecNacPersona);
                cmd.Parameters.AddWithValue("@prmstrDireccionPersona", usuario.persona.DireccionPersona);
                cmd.Parameters.AddWithValue("@prmstrCelularPersona", usuario.persona.CelularPersona);
                cmd.Parameters.AddWithValue("@prmstrDniPersona", usuario.persona.DniPersona);
                cmd.Parameters.AddWithValue("@prmstrUsername", usuario.Username);
                cmd.Parameters.AddWithValue("@prmstrPassword", usuario.Password);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { inserta = true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }


        public List<EntUsuario> ListarUsuario()
        {
            SqlCommand cmd = null;
            List<EntUsuario> lista = new List<EntUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntPersona persona = new EntPersona();
                    EntUsuario usuario = new EntUsuario();
                    usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                    usuario.Username = Convert.ToString(dr["Username"]);
                    usuario.Password = Convert.ToString(dr["Password"]);
                    usuario.Rol = Convert.ToString(dr["Rol"]);
                    usuario.EstadoUsuario = Convert.ToBoolean(dr["EstadoUsuario"]);
                    persona.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                    persona.NombresPersona = Convert.ToString(dr["NombresPersona"]);
                    persona.ApellidosPersona = Convert.ToString(dr["ApellidosPersona"]);
                    persona.FecNacPersona = Convert.ToDateTime(dr["FecNacPersona"]);
                    persona.DireccionPersona = Convert.ToString(dr["DireccionPersona"]);
                    persona.DniPersona = Convert.ToString(dr["DniPersona"]);
                    persona.CelularPersona = Convert.ToString(dr["CelularPersona"]);
                    
                    usuario.persona = persona;

                    lista.Add(usuario);

                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        public EntUsuario VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            EntUsuario usuario = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsername", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    EntPersona persona = new EntPersona();
                    usuario = new EntUsuario();
                    usuario.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                    usuario.Username = Convert.ToString(dr["Username"]);
                    usuario.Password = Convert.ToString(dr["Password"]);
                    usuario.Rol = Convert.ToString(dr["Rol"]);
                    usuario.EstadoUsuario = Convert.ToBoolean(dr["EstadoUsuario"]);

                    persona.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                    persona.NombresPersona = Convert.ToString(dr["NombresPersona"]);
                    persona.ApellidosPersona = Convert.ToString(dr["ApellidosPersona"]);
                    persona.FecNacPersona = Convert.ToDateTime(dr["FecNacPersona"]);
                    persona.DireccionPersona = Convert.ToString(dr["DireccionPersona"]);
                    persona.DniPersona = Convert.ToString(dr["DniPersona"]);
                    persona.CelularPersona = Convert.ToString(dr["CelularPersona"]);

                    usuario.persona = persona;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return usuario;
        }
        #endregion metodos
        
    }
}
