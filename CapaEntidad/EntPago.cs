using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntPago
    {
        public int PagoId { get; set; }

        public int ContratoId { get; set; }

        public DateTime FechaPago { get; set; }
        public float MontoPagado { get; set; }
    }
}
