using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteXUsuario
    {
        public int IdClienteVendedor { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Vendedor { get; set; }
    }
}
