using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompraXproducto
    {
        public int IdCompraProducto { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompraUnitario { get; set; }
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
