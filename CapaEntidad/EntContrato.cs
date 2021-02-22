using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntContrato
    {
        private int contratoId;

        public int ContratoId
        {
            get { return contratoId; }
            set { contratoId = value; }
        }

        private int usuarioId;

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        private EntPaquete paquete;

        public EntPaquete Paquete
        {
            get { return paquete; }
            set { paquete = value; }
        }

        private DateTime fechaContrato;

        public DateTime FechaContrato
        {
            get { return fechaContrato; }
            set { fechaContrato = value; }
        }

        private float montoTotal;

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        private float montoCancelado;

        public float MontoCancelado
        {
            get { return montoCancelado; }
            set { montoCancelado = value; }
        }

        private DateTime fechaEvento;

        public DateTime FechaEvento
        {
            get { return fechaEvento; }
            set { fechaEvento = value; }
        }
    }
}
