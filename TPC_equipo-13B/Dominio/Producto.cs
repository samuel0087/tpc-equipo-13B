using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public Proveedor Proveedor { get; set; }
        public long Stock { get; set; }
        public Tipo Tipo { get; set; }
    }
}
