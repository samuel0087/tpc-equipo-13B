using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdMetodoDePago { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal CostoTotal { get; set; }
        public bool Recibido { get; set; }
        public Proveedor Proveedor { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
    }
}
