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
        public void InsertarComprasConProductos(List<CompraXproducto> listaCompraProductos)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
              
                string query = "INSERT INTO compraXproducto (IdCompra, IdProducto, Cantidad, PrecioXcantidad, PrecioXunidad) " +
                               "VALUES (@IdCompra, @IdProducto, @Cantidad, @PrecioXcantidad, @PrecioXunidad)";

                
                datos.setearConsulta(query);

               
               
                    try
                    {
                       
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
                      
                        throw new Exception("Error al insertar las compras con productos: " + ex.Message);
                    }
                
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

