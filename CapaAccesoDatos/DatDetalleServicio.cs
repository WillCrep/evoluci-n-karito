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
    public class DatDetalleServicio
    {
        #region singleton
        private static readonly DatDetalleServicio instancia = new DatDetalleServicio();
        public static DatDetalleServicio Instancia
        {
            get
            {
                return DatDetalleServicio.instancia;
            }
        }
        #endregion singleton

        #region metodos
        public Boolean InsertarDetalleServicio(int ServicioId)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarDetalleServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintServicioId", ServicioId);
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
