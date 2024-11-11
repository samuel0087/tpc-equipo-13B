using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IdDeVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdVendedor { get; set; }
        public int IdMetodoDePago { get; set; }
        public bool FacturaGenerada { get; set; }
        public decimal CostoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Vendedor { get; set; }
        public MetodoDePago MetodoDePago { get; set; }

    }
}
