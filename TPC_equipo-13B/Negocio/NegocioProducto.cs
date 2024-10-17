using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProducto
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioProducto()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        // Agregar producto
        public void AgregarProducto(Producto producto)
        {
            string consulta = "INSERT INTO Productos (Codigo, Nombre, Marca, IdProveedor, Stock, Tipo) " +
                              "VALUES (@Codigo, @Nombre, @Marca, @IdProveedor, @Stock, @Tipo)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Codigo", producto.Codigo);
            accesoDatos.setearParametro("@Nombre", producto.Nombre);
            accesoDatos.setearParametro("@Marca", producto.Marca);
            accesoDatos.setearParametro("@IdProveedor", producto.IdProveedor);
            accesoDatos.setearParametro("@Stock", producto.Stock);
            accesoDatos.setearParametro("@Tipo", producto.Tipo);

            accesoDatos.ejecutarAccion();
        }

        // Modificar producto
        public void ModificarProducto(Producto producto)
        {
            string consulta = "UPDATE Productos SET Codigo = @Codigo, Nombre = @Nombre, Marca = @Marca, " +
                              "IdProveedor = @IdProveedor, Stock = @Stock, Tipo = @Tipo " +
                              "WHERE IdProducto = @IdProducto";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProducto", producto.IdProducto);
            accesoDatos.setearParametro("@Codigo", producto.Codigo);
            accesoDatos.setearParametro("@Nombre", producto.Nombre);
            accesoDatos.setearParametro("@Marca", producto.Marca);
            accesoDatos.setearParametro("@IdProveedor", producto.IdProveedor);
            accesoDatos.setearParametro("@Stock", producto.Stock);
            accesoDatos.setearParametro("@Tipo", producto.Tipo);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar producto
        public void EliminarProducto(int idProducto)
        {
            string consulta = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProducto", idProducto);

            accesoDatos.ejecutarAccion();
        }

        // Buscar productos
        public DataTable BuscarProductos(string nombre = null, int? codigo = null, string marca = null, int? idProveedor = null, long? stock = null, string tipo = null)
        {
            string consulta = "SELECT * FROM Productos WHERE 1=1";

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (codigo.HasValue)
            {
                consulta += " AND Codigo = @Codigo";
                accesoDatos.setearParametro("@Codigo", codigo.Value);
            }

            if (!string.IsNullOrEmpty(marca))
            {
                consulta += " AND Marca LIKE @Marca";
                accesoDatos.setearParametro("@Marca", "%" + marca + "%");
            }

            if (idProveedor.HasValue)
            {
                consulta += " AND IdProveedor = @IdProveedor";
                accesoDatos.setearParametro("@IdProveedor", idProveedor.Value);
            }

            if (stock.HasValue)
            {
                consulta += " AND Stock = @Stock";
                accesoDatos.setearParametro("@Stock", stock.Value);
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                consulta += " AND Tipo LIKE @Tipo";
                accesoDatos.setearParametro("@Tipo", "%" + tipo + "%");
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable productos = new DataTable();
            productos.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return productos;
        }
    }
}
