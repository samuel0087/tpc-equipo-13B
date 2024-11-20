using Acceso_Datos;
using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioStock
    {
        
        public void InsertarStock(Stock stock )
        {   
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "INSERT INTO stock (idproducto, cantidad) VALUES (@IdProducto, @Cantidad)";
                datos.setearConsulta(query);
               
                datos.setearParametro("@IdProducto",stock.IdProducto);
                datos.setearParametro("@Cantidad",stock.Cantidad);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar en la tabla stock: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
      
            public void ActualizarStock(int idProducto, int cantidadComprada)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    // Actualizar el stock sumando la cantidad comprada
                    string query = "UPDATE Stock SET Cantidad = Cantidad + @Cantidad WHERE IdProducto = @IdProducto";
                    datos.setearConsulta(query);
                    datos.setearParametro("@Cantidad", cantidadComprada);
                    datos.setearParametro("@IdProducto", idProducto);

                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el stock: " + ex.Message);
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
        
        //el siguiente metodo abria que modificarlo para que funcione correctamente 
        /*public void InsertarOActualizarStock(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL para verificar si el producto ya existe en la tabla stock
                string consultaVerificar = "SELECT COUNT(*) FROM stock WHERE idproducto = @IdProducto";
                datos.setearConsulta(consultaVerificar);
                datos.setearParametro("@IdProducto", stock.IdProducto);

                int existe = Convert.ToInt32(datos.ejecutarAccionEscalar());

                // Si el producto existe, actualizamos la cantidad
                if (existe > 0)
                {
                    string consultaActualizar = "UPDATE stock SET cantidad = cantidad + @Cantidad WHERE idproducto = @IdProducto";
                    datos.setearConsulta(consultaActualizar);
                    datos.setearParametro("@IdProducto", stock.IdProducto);
                    datos.setearParametro("@Cantidad", stock.Cantidad);
                }
                else // Si no existe, lo insertamos
                {
                    string consultaInsertar = "INSERT INTO stock (idproducto, cantidad) VALUES (@IdProducto, @Cantidad)";
                    datos.setearConsulta(consultaInsertar);
                    datos.setearParametro("@IdProducto", stock.IdProducto);
                    datos.setearParametro("@Cantidad", stock.Cantidad);
                }

                // Ejecutamos la consulta (ya sea INSERT o UPDATE)
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar o actualizar en la tabla stock: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/
    }
}

