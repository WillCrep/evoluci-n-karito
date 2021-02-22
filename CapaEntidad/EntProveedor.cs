using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntProveedor
    {
        private int proveedorId;

        public int ProveedorId
        {
            get { return proveedorId; }
            set { proveedorId = value; }
        }

        private string nombreProveedor;

        public string NombreProveedor
        {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

        private string celularProveedor;

        public string CelularProveedor
        {
            get { return celularProveedor; }
            set { celularProveedor = value; }
        }

        private string direccionProveedor;

        public string DireccionProveedor
        {
            get { return direccionProveedor; }
            set { direccionProveedor = value; }
        }

        private bool estadoProveedor;

        public bool EstadoProveedor
        {
            get { return estadoProveedor; }
            set { estadoProveedor = value; }
        }
    }
}

        