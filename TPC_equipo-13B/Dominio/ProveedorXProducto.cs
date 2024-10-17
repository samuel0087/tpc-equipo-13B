using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProveedorXProducto
    {   
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
    }
}
