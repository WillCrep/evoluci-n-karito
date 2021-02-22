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
    public class DatServicio
    {
        #region singleton
        private static readonly DatServicio instancia = new DatServicio();
        public static DatServicio Instancia
        {
            get
            {
                return DatServicio.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<EntServicio> ListarServicio()
        {
            SqlCommand cmd = null;
            List<EntServicio> lista = new List<EntServicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntServicio servicio = new EntServicio();

                    servicio.ServicioId = Convert.ToInt32(dr["ServicioId"]);
                    servicio.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    servicio.PrecioServicio = (float)Convert.ToDouble(dr["PrecioServicio"]);
                    lista.Add(servicio);

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

        public Boolean InsertarServicio(EntServicio Servicio)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreServicio", Servicio.NombreServicio);
                cmd.Parameters.AddWithValue("@prmfloatPrecioServicio", Servicio.PrecioServicio);
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


        public EntServicio BuscarServicio(int ServicioId)
        {
            SqlCommand cmd = null;
            EntServicio Servicio = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintServicioId", ServicioId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Servicio = new EntServicio();
                    Servicio.ServicioId = Convert.ToInt32(dr["ServicioId"]);
                    Servicio.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    Servicio.PrecioServicio = (float)Convert.ToDouble(dr["PrecioServicio"]);
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
            return Servicio;
        }

        public Boolean EditarServicio(EntServicio Servicio)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintServicioId", Servicio.ServicioId);
                cmd.Parameters.AddWithValue("@prmstrNombreServicio", Servicio.NombreServicio);
                cmd.Parameters.AddWithValue("@prmfloatPrecioServicio", Servicio.PrecioServicio);
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
        public Boolean BorrarServicio(int ServicioId)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBorrarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintServicioId", ServicioId);
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
