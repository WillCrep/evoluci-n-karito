using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntPersona
    {
        public int PersonaId { get; set; }
        public string NombresPersona { get; set; }
        public string ApellidosPersona { get; set; }
        public DateTime FecNacPersona { get; set; }
        public string DireccionPersona { get; set; }
        public string CelularPersona { get; set; }
        public string DniPersona { get; set; }
    }
}
