using Acceso_Datos;
using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public DataTable ObtenerStock()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "SELECT p.IdProducto, p.Nombre AS NombreProducto, s.Cantidad " +
                               "FROM Productos p " +
                               "INNER JOIN Stock s ON p.IdProducto = s.IdProducto";

                datos.setearConsulta(query);
                datos.ejecutarLectura();

                DataTable dtStock = new DataTable();
                dtStock.Load(datos.Lector); // Cargar los datos obtenidos en un DataTable
                return dtStock;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void EliminarStockPorIdProducto(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "DELETE FROM stock WHERE IdProducto = @IdProducto";
                datos.setearConsulta(query);
                datos.setearParametro("@IdProducto", idProducto);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el stock: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public ProductoStock ObtenerProductoPorId(int idProducto)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                // Definir la consulta SQL
                string consulta = "SELECT p.IdProducto, p.Nombre, s.Cantidad " +
                                  "FROM Productos p " +
                                  "INNER JOIN Stock s ON p.IdProducto = s.IdProducto " +
                                  "WHERE p.IdProducto = @IdProducto";

                // Configurar la consulta y los parámetros
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@IdProducto", idProducto);

                // Ejecutar la lectura
                accesoDatos.ejecutarLectura();

                // Verificar si hay resultados y mapearlos a un objeto ProductoStock
                if (accesoDatos.Lector.Read())
                {
                    return new ProductoStock
                    {
                        IdProducto = accesoDatos.Lector.GetInt32(0),
                        Nombre = accesoDatos.Lector.GetString(1),
                        Cantidad = accesoDatos.Lector.GetInt64(2)
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                throw new Exception("Error al obtener el producto por ID: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                accesoDatos.cerrarConexion();
            }

            // Si no se encuentra el producto, retornar null
            return null;
        }

        public bool ActualizarCantidadStock(int idProducto, int nuevaCantidad)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                // Definir la consulta SQL para actualizar el stock
                string consulta = "UPDATE Stock SET Cantidad = @NuevaCantidad WHERE IdProducto = @IdProducto";

                // Configurar la consulta y los parámetros
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@NuevaCantidad", nuevaCantidad);
                accesoDatos.setearParametro("@IdProducto", idProducto);

                // Ejecutar la acción
                int filasAfectadas = accesoDatos.ejecutarAccionEscalar() is int resultado ? resultado : 0;

                // Retornar si hubo filas afectadas
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                throw new Exception("Error al actualizar la cantidad de stock: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                accesoDatos.cerrarConexion();
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

