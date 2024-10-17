using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PruductoXCategoria
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public Producto Producto { get; set; }
        public Categoria Categoria { get; set; }
    }
}
