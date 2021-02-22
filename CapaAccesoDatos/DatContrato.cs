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
    public class DatContrato
    {

        #region singleton
        private static readonly DatContrato instancia = new DatContrato();
        public static DatContrato Instancia
        {
            get
            {
                return DatContrato.instancia;
            }
        }
        #endregion singleton
        #region metodos
        public Boolean InsertarContrato(EntContrato contrato)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarContrato", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUsuarioId", contrato.UsuarioId);
                cmd.Parameters.AddWithValue("@prmdateFechaEvento", contrato.FechaEvento);
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


        public List<EntContrato> ListarContrato(int UsuarioId)
        {
            SqlCommand cmd = null;
            List<EntContrato> lista = new List<EntContrato>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarContratoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUsuarioId",UsuarioId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntContrato Contrato = new EntContrato();

                    EntPaquete Paquete = new EntPaquete();

                    Contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                    Contrato.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                    Paquete.PaqueteId = Convert.ToInt32(dr["PaqueteId"]);
                    Contrato.FechaContrato = Convert.ToDateTime(dr["FechaContrato"]);
                    Contrato.FechaEvento = Convert.ToDateTime(dr["FechaEvento"]);
                    Contrato.MontoTotal = (float)Convert.ToDouble(dr["MontoTotal"]);
                    Contrato.MontoCancelado = (float)Convert.ToDouble(dr["MontoCancelado"]);

                    Contrato.Paquete = Paquete;
                    lista.Add(Contrato);

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


        public EntContrato DetallarContrato(int ContratoId)
        {
            SqlCommand cmd = null;
            EntContrato Contrato  = new EntContrato();
            EntPaquete Paquete = new EntPaquete();
            List<EntDetalleServicio> ListaDetalleServicio = new List<EntDetalleServicio>();
            List<EntDetalleUtileria> ListaDetalleUtileria = new List<EntDetalleUtileria>();
            


            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVisualizarCabeceraContrato", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintContratoId", ContratoId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                    Contrato.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                    Contrato.FechaContrato = Convert.ToDateTime(dr["FechaContrato"]);
                    Contrato.MontoTotal = (float)Convert.ToDouble(dr["MontoTotal"]);
                    Contrato.MontoCancelado = (float)Convert.ToDouble(dr["MontoCancelado"]);
                    Contrato.FechaEvento = Convert.ToDateTime(dr["FechaEvento"]);
                    
                    
                    
                    Paquete.PaqueteId = Convert.ToInt32(dr["PaqueteId"]);
                    Paquete.MontoTotal = (float)Convert.ToDouble(dr["MontoTotal"]);


                    EntTematica Tematica = new EntTematica();

                    Tematica.TematicaId = Convert.ToInt32(dr["TematicaId"]);
                    Tematica.NombreTematica = Convert.ToString(dr["NombreTematica"]);

                    Paquete.Tematica = Tematica;
                    

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


            cmd = null;
            
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVisualizarDetalleServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintPaqueteId",Paquete.PaqueteId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntDetalleServicio DetalleServicio = new EntDetalleServicio();

                    DetalleServicio.DetalleServicioId = Convert.ToInt32(dr["DetalleServicioId"]);
                    DetalleServicio.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    DetalleServicio.PrecioServicio = (float)Convert.ToDouble(dr["PrecioServicio"]);
                    
                    EntServicio Servicio = new EntServicio();

                    Servicio.ServicioId = Convert.ToInt32(dr["ServicioId"]);
                    Servicio.NombreServicio = Convert.ToString(dr["NombreServicio"]);
                    Servicio.PrecioServicio = (float)Convert.ToDouble(dr["PrecioServicio"]);

                    DetalleServicio.Servicio = Servicio;


                    ListaDetalleServicio.Add(DetalleServicio);

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


            Paquete.Servicios = new List<EntDetalleServicio>();
            Paquete.Servicios = ListaDetalleServicio;


            cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVisualizarDetalleUtileria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintPaqueteId", Paquete.PaqueteId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntDetalleUtileria DetalleUtileria = new EntDetalleUtileria();
                    EntUtileria Utileria = new EntUtileria();
                    
                    
                    DetalleUtileria.DetalleUtileriaId = Convert.ToInt32(dr["DetalleUtileriaId"]);
                    DetalleUtileria.NombreUtileria = Convert.ToString(dr["NombreUtileria"]);
                    DetalleUtileria.ColorUtileria = Convert.ToString(dr["ColorUtileria"]);
                    DetalleUtileria.CantidadUtileria = Convert.ToInt32(dr["CantidadUtileria"]);
                    DetalleUtileria.SubTotalUtileria = (float)Convert.ToDouble(dr["SubTotalUtileria"]);
                    
                    
                    Utileria.UtileriaId = Convert.ToInt32(dr["UtileriaId"]);
                    Utileria.NombreUtileria = Convert.ToString(dr["NombreUtileria"]);
                    Utileria.ColorUtileria = Convert.ToString(dr["ColorUtileria"]);
                    Utileria.PrecioUtileria = (float)Convert.ToDouble(dr["PrecioUnitario"]);


                    DetalleUtileria.Utileria = Utileria;


                    ListaDetalleUtileria.Add(DetalleUtileria);

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

            Paquete.Utileria = new List<EntDetalleUtileria>();
            Paquete.Utileria = ListaDetalleUtileria;

            Contrato.Paquete = Paquete;

            return Contrato;
        }


        #endregion metodos
    }
}
