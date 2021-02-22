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
    public class DatPago
    {
        #region singleton
        private static readonly DatPago instancia = new DatPago();
        public static DatPago Instancia
        {
            get
            {
                return DatPago.instancia;
            }
        }
        #endregion singleton
        #region metodos
        
        public Boolean InsertarPago(EntPago Pago)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintContratoId", Pago.ContratoId);
                cmd.Parameters.AddWithValue("@prmfloatMontoPagado", Pago.MontoPagado);
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

        public float GananciaDelMes(int Mes)
        {
            SqlCommand cmd = null;
            float ganancia = 0;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCalcularGananciasDelMes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintMes", Mes);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntServicio servicio = new EntServicio();

                   ganancia = Convert.ToInt32(dr["Ganancia"]);

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
            return ganancia;
        }
        #endregion
    }
    
}
