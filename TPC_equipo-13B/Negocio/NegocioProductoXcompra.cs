using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProductoXcompra
    {
        // Método para guardar un registro en la tabla compraXproducto
        
            public void InsertarCompraConProductos(CompraXproducto compraProducto)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    // Configurar la consulta SQL
                    string query = "INSERT INTO CompraProductos (IdCompra, IdProducto, Cantidad, PrecioXcantidad) " +
                                   "VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioXcantidad)";
                    datos.setearConsulta(query);

                    // Configurar los parámetros
                    datos.setearParametro("@IdCompra", compraProducto.IdCompra);
                    datos.setearParametro("@IdProducto", compraProducto.IdProducto);
                    datos.setearParametro("@Cantidad", compraProducto.Cantidad);
                    datos.setearParametro("@PrecioXcantidad", compraProducto.precioXcantidad);

                    // Ejecutar la acción
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar CompraXproducto: " + ex.Message);
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
    }
}

