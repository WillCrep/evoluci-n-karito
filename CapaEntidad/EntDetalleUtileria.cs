using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntDetalleUtileria
    {
        private int detalleUtileriaId;

        public int DetalleUtileriaId
        {
            get { return detalleUtileriaId; }
            set { detalleUtileriaId = value; }
        }

        private EntPaquete paquete;

        public EntPaquete Paquete
        {
            get { return paquete; }
            set { paquete = value; }
        }

        private EntUtileria utileria;

        public EntUtileria Utileria
        {
            get { return utileria; }
            set { utileria = value; }
        }

        private string nombreUtileria;

        public string NombreUtileria
        {
            get { return nombreUtileria; }
            set { nombreUtileria = value; }
        }

        private string colorUtileria;

        public string ColorUtileria
        {
            get { return colorUtileria; }
            set { colorUtileria = value; }
        }

        private int cantidadUtileria;

        public int CantidadUtileria
        {
            get { return cantidadUtileria; }
            set { cantidadUtileria = value; }
        }

        private float precioUnitario;

        public float PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        private float subTotalUtileria;

        public float SubTotalUtileria
        {
            get { return subTotalUtileria; }
            set { subTotalUtileria = value; }
        }
    }
}
