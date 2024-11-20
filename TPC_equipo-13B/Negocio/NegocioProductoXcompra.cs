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

                

                foreach (var compraProducto in listaCompraProductos)
                {
                    // Limpiar los parámetros antes de cada iteración
                    datos.limpiarParametros();
                    datos.setearConsulta(query);
                    // Establecer los nuevos valores de los parámetros
                    datos.setearParametro("@IdCompra", compraProducto.IdCompra);
                    datos.setearParametro("@IdProducto", compraProducto.IdProducto);
                    datos.setearParametro("@Cantidad", compraProducto.Cantidad);
                    datos.setearParametro("@PrecioXcantidad", compraProducto.precioXcantidad);
                    datos.setearParametro("@PrecioXunidad", compraProducto.PrecioXunidad);

                    // Ejecutar la acción
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                // Capturar errores específicos del proceso y re-lanzarlos
                throw new Exception("Error al insertar las compras con productos: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión sin importar lo que suceda
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

