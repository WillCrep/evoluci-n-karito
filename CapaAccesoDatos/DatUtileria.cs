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
    public class DatUtileria
    {
        #region singleton
        private static readonly DatUtileria instancia = new DatUtileria();
        public static DatUtileria Instancia
        {
            get
            {
                return DatUtileria.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<EntUtileria> ListarUtileria()
        {
            SqlCommand cmd = null;
            List<EntUtileria> lista = new List<EntUtileria>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntUtileria utileria = new EntUtileria();

                    utileria.UtileriaId = Convert.ToInt32(dr["UtileriaId"]);
                    utileria.NombreUtileria = Convert.ToString(dr["NombreUtileria"]);
                    utileria.ColorUtileria = Convert.ToString(dr["ColorUtileria"]);
                    utileria.Ancho = (float)Convert.ToDouble(dr["Ancho"]);
                    utileria.Alto= (float)Convert.ToDouble(dr["Alto"]);
                    utileria.Largo= (float)Convert.ToDouble(dr["Largo"]);
                    utileria.StockUtileria = Convert.ToInt32(dr["StockUtileria"]);
                    utileria.PrecioUtileria = (float)Convert.ToDouble(dr["PrecioUtileria"]);
                    
                    
                    lista.Add(utileria);

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

        public Boolean InsertarUtileria(EntUtileria Utileria)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreUtileria", Utileria.NombreUtileria);
                cmd.Parameters.AddWithValue("@prmstrColorUtileria", Utileria.ColorUtileria);
                cmd.Parameters.AddWithValue("@prmfloatAncho", Utileria.Ancho);
                cmd.Parameters.AddWithValue("@prmfloatLargo", Utileria.Largo);
                cmd.Parameters.AddWithValue("@prmfloatAlto", Utileria.Alto);
                cmd.Parameters.AddWithValue("@prmintStockUtileria", Utileria.StockUtileria);
                cmd.Parameters.AddWithValue("@prmfloatPrecioUtileria", Utileria.PrecioUtileria);
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


        public EntUtileria BuscarUtileria(int UtileriaId)
        {
            SqlCommand cmd = null;
            EntUtileria utileria = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUtileriaId", UtileriaId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    utileria = new EntUtileria();
                    utileria.UtileriaId = Convert.ToInt32(dr["UtileriaId"]);
                    utileria.NombreUtileria = Convert.ToString(dr["NombreUtileria"]);
                    utileria.ColorUtileria = Convert.ToString(dr["ColorUtileria"]);
                    utileria.Ancho = (float)Convert.ToDouble(dr["Ancho"]);
                    utileria.Alto = (float)Convert.ToDouble(dr["Alto"]);
                    utileria.Largo = (float)Convert.ToDouble(dr["Largo"]);
                    utileria.StockUtileria = Convert.ToInt32(dr["StockUtileria"]);
                    utileria.PrecioUtileria = (float)Convert.ToDouble(dr["PrecioUtileria"]);
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
            return utileria;
        }

        public Boolean EditarUtileria(EntUtileria Utileria)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //spEditarUtileria @prmintUtileriaId int, @prmstrNombreUtileria varchar(50), @prmstrColorUtileria varchar(50),  @prmfloatAncho decimal(10,2) , @prmfloatLargo decimal(10,2), @prmfloatAlto decimal(10,2), @prmintStockUtileria int, @prmfloatPrecioUtileria decimal(10,2)

                cmd.Parameters.AddWithValue("@prmintUtileriaId", Utileria.UtileriaId);
                cmd.Parameters.AddWithValue("@prmstrNombreUtileria", Utileria.NombreUtileria);
                cmd.Parameters.AddWithValue("@prmstrColorUtileria", Utileria.ColorUtileria);
                cmd.Parameters.AddWithValue("@prmfloatAncho", Utileria.Ancho);
                cmd.Parameters.AddWithValue("@prmfloatLargo", Utileria.Largo);
                cmd.Parameters.AddWithValue("@prmfloatAlto", Utileria.Alto);
                cmd.Parameters.AddWithValue("@prmintStockUtileria", Utileria.StockUtileria);
                cmd.Parameters.AddWithValue("@prmfloatPrecioUtileria", Utileria.PrecioUtileria);
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
        public Boolean BorrarUtileria(int UtileriaId)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBorrarUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUtileriaId", UtileriaId);
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
