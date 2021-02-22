using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntTematica
    {
        private int tematicaId;

        public int TematicaId
        {
            get { return tematicaId; }
            set { tematicaId = value; }
        }

        private string nombreTematica;

        public string NombreTematica
        {
            get { return nombreTematica; }
            set { nombreTematica = value; }
        }
        private bool estadoTematica;

        public bool EstadoTematica
        {
            get { return estadoTematica; }
            set { estadoTematica = value; }
        }
    }
}
