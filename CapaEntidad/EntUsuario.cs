using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUsuario
    {
        public int UsuarioId { get; set; }
        public EntPersona persona { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool EstadoUsuario { get; set; }
    }
}
