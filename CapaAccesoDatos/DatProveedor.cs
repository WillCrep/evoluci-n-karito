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
    public class DatProveedor
    {
        #region singleton
        private static readonly DatProveedor instancia = new DatProveedor();
        public static DatProveedor Instancia
        {
            get
            {
                return DatProveedor.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<EntProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<EntProveedor> lista = new List<EntProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProveedor proveedor = new EntProveedor();

                    proveedor.ProveedorId = Convert.ToInt32(dr["ProveedorId"]);
                    proveedor.NombreProveedor = Convert.ToString(dr["NombreProveedor"]);
                    proveedor.CelularProveedor = Convert.ToString(dr["CelularProveedor"]);
                    proveedor.DireccionProveedor = Convert.ToString(dr["DireccionProveedor"]);

                    lista.Add(proveedor);

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

        public Boolean InsertarProveedor(EntProveedor Proveedor)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                ///@prmintTematicaId int, @prmfloatMontoTotal decimal(10,2)
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreProveedor", Proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@prmstrCelularProveedor", Proveedor.CelularProveedor);
                cmd.Parameters.AddWithValue("@prmstrDireccionProveedor", Proveedor.DireccionProveedor);
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


        public EntProveedor BuscarProveedor(int ProveedorId)
        {
            SqlCommand cmd = null;
            EntProveedor proveedor = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProveedorId", ProveedorId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    proveedor = new EntProveedor();
                    proveedor.ProveedorId = Convert.ToInt32(dr["ProveedorId"]);
                    proveedor.NombreProveedor = Convert.ToString(dr["NombreProveedor"]);
                    proveedor.CelularProveedor = Convert.ToString(dr["CelularProveedor"]);
                    proveedor.DireccionProveedor = Convert.ToString(dr["DireccionProveedor"]);
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
            return proveedor;
        }

        public Boolean EditarProveedor(EntProveedor Proveedor)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //spEditarUtileria @prmintUtileriaId int, @prmstrNombreUtileria varchar(50), @prmstrColorUtileria varchar(50),  @prmfloatAncho decimal(10,2) , @prmfloatLargo decimal(10,2), @prmfloatAlto decimal(10,2), @prmintStockUtileria int, @prmfloatPrecioUtileria decimal(10,2)

                cmd.Parameters.AddWithValue("@prmintProveedorId", Proveedor.ProveedorId);
                cmd.Parameters.AddWithValue("@prmstrNombreProveedor", Proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@prmstrCelularProveedor", Proveedor.CelularProveedor);
                cmd.Parameters.AddWithValue("@prmstrDireccionProveedor", Proveedor.DireccionProveedor);
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
        public Boolean BorrarProveedor(int ProveedorId)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBorrarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProveedorId", ProveedorId);
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