using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PrecioXProducto
    {
        public int IdProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVigencia { get; set; }
        public Producto Producto { get; set; }
    }
}
