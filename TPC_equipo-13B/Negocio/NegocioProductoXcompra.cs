using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProductoXcompra
    {
        public void InsertarComprasConProductos(List<CompraXproducto> listaCompraProductos)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "INSERT INTO compraXproducto (IdCompra, IdProducto, Cantidad, PrecioXcantidad, PrecioXunidad) " +
                               "VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioXcantidad, @PrecioXunidad)";

                datos.setearConsulta(query);

                foreach (var compraProducto in listaCompraProductos)
                {
                    datos.setearParametro("@IdCompra", compraProducto.IdCompra);
                    datos.setearParametro("@IdProducto", compraProducto.IdProducto);
                    datos.setearParametro("@Cantidad", compraProducto.Cantidad);
                    datos.setearParametro("@PrecioXcantidad", compraProducto.precioXcantidad);
                    datos.setearParametro("@PrecioXunidad", compraProducto.PrecioXunidad);

                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                // Captura el error si ocurre
                throw new Exception("Error al insertar las compras con productos: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión solo después de insertar todos los productos
                datos.cerrarConexion();
            }
        }

        public DataTable CargarDetallesCompra(int idCompra)
        {
            AccesoDatos datos = new AccesoDatos();
           
                string query = @"
                    SELECT cxp.idproducto AS IdProducto, cxp.cantidad AS Cantidad, 
                           cxp.precioXunidad AS PrecioXUnidad, cxp.precioXcantidad AS PrecioXCantidad
                    FROM compraXproducto cxp
                    WHERE cxp.idcompra = @IdCompra";

                datos.setearConsulta(query);
                datos.setearParametro("@IdCompra", idCompra);
                datos.ejecutarLectura();

                DataTable dt = new DataTable();
                dt.Load(datos.Lector);
                datos.cerrarConexion();

                return dt;
        }
        
    }      
}

