using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUtileria
    {
        private int utileriaId;

        public int UtileriaId
        {
            get { return utileriaId; }
            set { utileriaId = value; }
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

        private float ancho;

        public float Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }

        private float largo;

        public float Largo
        {
            get { return largo; }
            set { largo = value; }
        }

        private float alto;

        public float Alto
        {
            get { return alto; }
            set { alto = value; }
        }

        private int stockUtileria;

        public int StockUtileria
        {
            get { return stockUtileria; }
            set { stockUtileria = value; }
        }

        private float precioUtileria;

        public float PrecioUtileria
        {
            get { return precioUtileria; }
            set { precioUtileria = value; }
        }

        private bool estadoUtileria;

        public bool EstadoUtileria
        {
            get { return estadoUtileria; }
            set { estadoUtileria = value; }
        }
    }
}
