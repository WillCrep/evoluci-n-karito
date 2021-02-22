using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class DatPaquete
    {
        #region singleton
        private static readonly DatPaquete instancia = new DatPaquete();
        public static DatPaquete Instancia
        {
            get
            {
                return DatPaquete.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public Boolean InsertarPaquete(EntPaquete paquete)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPaquete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTematicaId", paquete.Tematica.TematicaId);
                cmd.Parameters.AddWithValue("@prmfloatMontoTotal", paquete.MontoTotal);
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

        public Boolean CalcularMontoTotal()
        {
            SqlCommand cmd = null;
            Boolean calcula = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCalcularTotalPaquete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { calcula= true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return calcula;
        }


         public List<EntPaquete> ListarPaquete()
        {
            SqlCommand cmd = null;
            List<EntPaquete> lista = new List<EntPaquete>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPaquete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntPaquete paquete = new EntPaquete();

                    paquete.PaqueteId = Convert.ToInt32(dr["PaqueteId"]);
                    paquete.MontoTotal = (float) Convert.ToDouble(dr["MontoTotal"]);
                    paquete.Tematica.TematicaId = Convert.ToInt32(dr["TematicaId"]);
                    paquete.Tematica.NombreTematica = Convert.ToString(dr["NombreTematica"]);

                    lista.Add(paquete);

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
