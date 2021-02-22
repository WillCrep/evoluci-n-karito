using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntServicio
    {
        private int servicioId;

        public int ServicioId
        {
            get { return servicioId; }
            set { servicioId = value; }
        }

        private string nombreServicio;

        public string NombreServicio
        {
            get { return nombreServicio; }
            set { nombreServicio = value; }
        }

        private float precioServicio;

        public float PrecioServicio
        {
            get { return precioServicio; }
            set { precioServicio = value; }
        }

        private bool estadoServicio;

        public bool EstadoServicio
        {
            get { return estadoServicio; }
            set { estadoServicio = value; }
        }
    }
}
