using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntPaquete
    {
        private int paqueteId;

        public int PaqueteId
        {
            get { return paqueteId; }
            set { paqueteId = value; }
        }

        private EntTematica tematica;

        public EntTematica Tematica
        {
            get { return tematica; }
            set { tematica = value; }
        }

        private float montoTotal;

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public List<EntDetalleServicio> Servicios { get; set; }

        public List<EntDetalleUtileria> Utileria { get; set; }

    }
}
