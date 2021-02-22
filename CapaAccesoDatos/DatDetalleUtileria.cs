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
    public class DatDetalleUtileria
    {
        #region singleton
        private static readonly DatDetalleUtileria instancia = new DatDetalleUtileria();
        public static DatDetalleUtileria Instancia
        {
            get
            {
                return DatDetalleUtileria.instancia;
            }
        }
        #endregion singleton

        #region metodos
        public Boolean InsertarDetalleUtileria(int UtileriaId, int CantidadUtileria )
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarDetalleUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUtileriaId", UtileriaId);
                cmd.Parameters.AddWithValue("@prmintCantidadUtileria", CantidadUtileria);
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

        #endregion metodos
    }
}
