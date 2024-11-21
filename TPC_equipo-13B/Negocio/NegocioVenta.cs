using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioVenta
    {
        public void InsertarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            // Insertar la venta
            string insertarCompraQuery = "INSERT INTO Ventas (IdCliente, Fecha, IdVendedor, IdMetodoPago, CostoTotal, NumeroFactura) " +
                                         "VALUES (@IdCliente, @Fecha,@IdVendedor,IdMetodoPago, @CostoTotal, @NumeroFactura)";
            datos.setearConsulta(insertarCompraQuery);

            // Configurar parámetros
            datos.setearParametro("@IdProveedor", venta.Cliente.ID);
            datos.setearParametro("@fecha", venta.Fecha);
            datos.setearParametro("@IdVendedor", venta.Vendedor.IdUsuario);
            datos.setearParametro("@IdMetodoPago", venta.MetodoDePago.IdMetodoDePago);
            datos.setearParametro("@CostoTotal", venta.CostoTotal);
            datos.setearParametro("@NumeroFactura", venta.NumeroFactura);

            datos.ejecutarAccion();


        }

        public int generarCodigoFactura()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            int codigo = 0;
            try
            {
                string query = "select count(*) AS cantidadVentas from Ventas";
                accesoDatos.setearConsulta(query);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    codigo = accesoDatos.Lector["cantidadVentas"] is DBNull ? 0 : (int)accesoDatos.Lector["cantidadVentas"];
                }

                return codigo + 10001;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public Venta buscarVentaPorFactura(Venta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"Select IdVenta From Ventas where NumeroFactura = @numero ");
                datos.setearParametro("@numero", aux.NumeroFactura);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.IdDeVenta = datos.Lector["IdVenta"] is DBNull ? 0 : (int)datos.Lector["IdVenta"];
                }

                return aux;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void registrarProductos(Venta aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "INSERT INTO VentasXProductos (IdVenta, IdProducto, Cantidad, PrecioXcantidad, PrecioXunidad) " +
                               "VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioXcantidad, @PrecioXunidad)";



                foreach (var ventaProducto in aux.Productos)
                {
                    // Limpiar los parámetros antes de cada iteración
                    datos.limpiarParametros();
                    datos.setearConsulta(query);
                    // Establecer los nuevos valores de los parámetros
                    datos.setearParametro("@IdVenta", aux.IdDeVenta);
                    datos.setearParametro("@IdProducto", ventaProducto.IdProducto);
                    datos.setearParametro("@Cantidad", ventaProducto.Cantidad);
                    datos.setearParametro("@PrecioXcantidad", (ventaProducto.Cantidad * ventaProducto.PecioFinal));
                    datos.setearParametro("@PrecioXunidad", ventaProducto.PecioFinal);

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

    }
}
