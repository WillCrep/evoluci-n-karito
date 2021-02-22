using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntDetalleServicio
    {
        private int detalleServicioId;

        public int DetalleServicioId
        {
            get { return detalleServicioId; }
            set { detalleServicioId = value; }
        }

        private EntPaquete paquete;

        public EntPaquete Paquete
        {
            get { return paquete; }
            set { paquete = value; }
        }

        private EntServicio servicio;

        public EntServicio Servicio
        {
            get { return servicio; }
            set { servicio = value; }
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
    }
}
