using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton
        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=.; initial Catalog=KaritoWebConFe;" + "Integrated Security=true";
            cn.ConnectionString = "Data Source=localhost; initial Catalog=KaritoWebConFe; User Id = upn; Password = Upn2020;";

            return cn;
        }
        #endregion metodos
    }
}
