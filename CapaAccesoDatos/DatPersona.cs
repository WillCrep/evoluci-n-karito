using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaAccesoDatos
{
    public class DatPersona
    {
        #region singleton
        private static readonly DatPersona instancia = new DatPersona();
        public static DatPersona Instancia
        {
            get
            {
                return DatPersona.instancia;
            }
        }
        #endregion singleton

        #region metodos
        public Boolean InsertarPersona(EntPersona persona)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                //@prmstrNombresPersona, @prmstrApellidosPersona , @prmdatetimeFecNacPersona , @prmstrDireccionPersona, @prmstrCelularPersona, @prmstrDniPersona
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombresPersona", persona.NombresPersona);
                cmd.Parameters.AddWithValue("@prmstrApellidosPersona", persona.ApellidosPersona);
                cmd.Parameters.AddWithValue("@prmdatetimeFecNacPersona", persona.FecNacPersona);
                cmd.Parameters.AddWithValue("@prmstrDireccionPersona", persona.DireccionPersona);
                cmd.Parameters.AddWithValue("@prmstrCelularPersona", persona.CelularPersona);
                cmd.Parameters.AddWithValue("@prmstrDniPersona", persona.DniPersona);
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

        public List<EntPersona> ListarPersona()
        {
            SqlCommand cmd = null;
            List<EntPersona> lista = new List<EntPersona>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntPersona persona = new EntPersona();
                    

                    persona.PersonaId = Convert.ToInt32(dr["PersonaId"]);
                    persona.NombresPersona = Convert.ToString(dr["NombresPersona"]);
                    persona.ApellidosPersona = Convert.ToString(dr["ApellidosPersona"]);
                    persona.FecNacPersona = Convert.ToDateTime(dr["FecNacPersona"]);
                    persona.DireccionPersona = Convert.ToString(dr["DireccionPersona"]);
                    persona.DniPersona = Convert.ToString(dr["DniPersona"]);
                    persona.CelularPersona = Convert.ToString(dr["CelularPersona"]);


                    lista.Add(persona);

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
        #endregion metodos
    }
}
