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
        public Tipo Tipo { get; set; }
        public Decimal Ganancia { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }  
    }
}
