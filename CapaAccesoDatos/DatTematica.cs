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
    public class DatTematica
    {
        #region singleton
        private static readonly DatTematica instancia = new DatTematica();
        public static DatTematica Instancia
        {
            get
            {
                return DatTematica.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<EntTematica> ListarTematica()
        {
            SqlCommand cmd = null;
            List<EntTematica> lista = new List<EntTematica>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTematica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntTematica tematica = new EntTematica();

                    tematica.TematicaId = Convert.ToInt32(dr["TematicaId"]);
                    tematica.NombreTematica = Convert.ToString(dr["NombreTematica"]);

                    lista.Add(tematica);

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

        public Boolean InsertarTematica(EntTematica Tematica)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTematica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreTematica", Tematica.NombreTematica);
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

        public EntTematica BuscarTematica(int TematicaId)
        {
            SqlCommand cmd = null;
            EntTematica tematica = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarTematica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTematicaId", TematicaId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    tematica = new EntTematica();
                    tematica.TematicaId = Convert.ToInt32(dr["TematicaId"]);
                    tematica.NombreTematica = Convert.ToString(dr["NombreTematica"]);
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
            return tematica;
        }

        public Boolean EditarTematica(EntTematica Tematica)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarTematica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTematicaId", Tematica.TematicaId);
                cmd.Parameters.AddWithValue("@prmstrNombreTematica", Tematica.NombreTematica);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        public Boolean BorrarTematica(int TematicaId)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBorrarTematica", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTematicaId", TematicaId);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }
        #endregion
    }
}
