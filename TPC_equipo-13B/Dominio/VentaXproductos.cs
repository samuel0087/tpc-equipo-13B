using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaXproductos
    {
        public int IdVentaProducto { get; set; }
        public int IdDeVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
