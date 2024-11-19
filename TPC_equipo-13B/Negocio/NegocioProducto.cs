using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Producto> listar()
        {
            AccesoDatos datos = new AccesoDatos();

            List<Producto> lista = new List<Producto>();

            string consulta = @"Select P.IdProducto, P.Codigo, P.Nombre, P.Ganancia, M.IdMarca, M.Nombre As MarcaNombre , T.IdTipo, T.Nombre As TipoNombre from Productos P
                                Left join Marcas M On M.IdMarca = P.IdMarca
                                Left Join Tipos T On T.IdTipo = P.IdTipo";
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = datos.Lector["IdProducto"] is DBNull ? 0 : (int)datos.Lector["IdProducto"] ;
                    aux.Codigo = datos.Lector["Codigo"] is DBNull ? 0 : (int)datos.Lector["Codigo"] ;
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"] ;
                    aux.Ganancia = datos.Lector["Ganancia"] is DBNull ? 0 : Convert.ToDecimal(datos.Lector["Ganancia"]) ;

                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = datos.Lector["IdMarca"] is DBNull ? 0 : (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = datos.Lector["MarcaNombre"] is DBNull ? "" : (string)datos.Lector["MarcaNombre"];

                    aux.Tipo = new Tipo();
                    aux.Tipo.IdTipo = datos.Lector["IdTipo"] is DBNull ? 0 : (int)datos.Lector["IdTipo"];
                    aux.Tipo.Nombre = datos.Lector["TipoNombre"] is DBNull ? "" : (string)datos.Lector["TipoNombre"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public Producto getOne(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            Producto aux = new Producto();

            string consulta = @"Select P.IdProducto, P.Codigo, P.Nombre, P.Ganancia, M.IdMarca, M.Nombre As MarcaNombre , T.IdTipo, T.Nombre As TipoNombre from Productos P
                                Left join Marcas M On M.IdMarca = P.IdMarca
                                Left Join Tipos T On T.IdTipo = P.IdTipo
                                Where P.IdProducto = @Id";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    aux.IdProducto = datos.Lector["IdProducto"] is DBNull ? 0 : (int)datos.Lector["IdProducto"];
                    aux.Codigo = datos.Lector["Codigo"] is DBNull ? 0 : (int)datos.Lector["Codigo"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Ganancia = datos.Lector["Ganancia"] is DBNull ? 0 : Convert.ToDecimal(datos.Lector["Ganancia"]);

                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = datos.Lector["IdMarca"] is DBNull ? 0 : (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = datos.Lector["MarcaNombre"] is DBNull ? "" : (string)datos.Lector["MarcaNombre"];

                    aux.Tipo = new Tipo();
                    aux.Tipo.IdTipo = datos.Lector["IdTipo"] is DBNull ? 0 : (int)datos.Lector["IdTipo"];
                    aux.Tipo.Nombre = datos.Lector["TipoNombre"] is DBNull ? "" : (string)datos.Lector["TipoNombre"];
                }

                return aux;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        // Agregar producto
        public void AgregarProducto(Producto producto)
        {
            string consulta = "INSERT INTO Productos (Codigo, Nombre, IdMarca, IdTipo, Ganancia) " +
                                             "VALUES (@Codigo, @Nombre, @IdMarca, @IdTipo, @Ganancia)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Codigo", producto.Codigo);
            accesoDatos.setearParametro("@Nombre", producto.Nombre);
            accesoDatos.setearParametro("@IdMarca", producto.Marca.IdMarca);
            accesoDatos.setearParametro("@IdTipo", producto.Tipo.IdTipo);
            accesoDatos.setearParametro("@Ganancia", producto.Ganancia);

            accesoDatos.ejecutarAccion();
        }

        public Producto buscarProductoPorId(int id)
        {
            Producto producto = null;
            string consulta = @"Select P.IdProducto, P.Codigo, P.Nombre, P.Ganancia, M.IdMarca, M.Nombre As MarcaNombre , T.IdTipo, T.Nombre As TipoNombre from Productos P
                                Left join Marcas M On M.IdMarca = P.IdMarca
                                Left Join Tipos T On T.IdTipo = P.IdTipo
                                Where P.IdProducto = @IdProducto";

            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@IdProducto", id);

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.IdProducto = accesoDatos.Lector["IdProducto"] is DBNull ? 0 : (int)accesoDatos.Lector["IdProducto"];
                    producto.Codigo = accesoDatos.Lector["Codigo"] is DBNull ? 0 : (int)accesoDatos.Lector["Codigo"];
                    producto.Nombre = accesoDatos.Lector["Nombre"] is DBNull ? "" : (string)accesoDatos.Lector["Nombre"];
                    producto.Ganancia = accesoDatos.Lector["Ganancia"] is DBNull ? 0 : Convert.ToDecimal(accesoDatos.Lector["Ganancia"]);

                    producto.Marca = new Marca();
                    producto.Marca.IdMarca = accesoDatos.Lector["IdMarca"] is DBNull ? 0 : (int)accesoDatos.Lector["IdMarca"];
                    producto.Marca.Nombre = accesoDatos.Lector["MarcaNombre"] is DBNull ? "" : (string)accesoDatos.Lector["MarcaNombre"];

                    producto.Tipo = new Tipo();
                    producto.Tipo.IdTipo = accesoDatos.Lector["IdTipo"] is DBNull ? 0 : (int)accesoDatos.Lector["IdTipo"];
                    producto.Tipo.Nombre = accesoDatos.Lector["TipoNombre"] is DBNull ? "" : (string)accesoDatos.Lector["TipoNombre"];
                }

                accesoDatos.cerrarConexion();
                return producto;
            }
            catch(Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        // Modificar producto
        public void ModificarProducto(Producto producto)
        {
            string consulta = "UPDATE Productos SET Codigo = @Codigo, Nombre = @Nombre, IdMarca = @Marca, " +
                              "IdTipo = @Tipo, Ganancia = @Ganancia " +
                              "WHERE IdProducto = @IdProducto";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProducto", producto.IdProducto);
            accesoDatos.setearParametro("@Codigo", producto.Codigo);
            accesoDatos.setearParametro("@Nombre", producto.Nombre);
            accesoDatos.setearParametro("@Marca", producto.Marca.IdMarca);
            accesoDatos.setearParametro("@Tipo", producto.Tipo.IdTipo);
            accesoDatos.setearParametro("@Ganancia", producto.Ganancia);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar producto
        public void EliminarProducto(Producto aux)
        {
            string consulta = "DELETE FROM Productos WHERE IdProducto = @IdProducto";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProducto", aux.IdProducto);

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

        public DataTable cargartaProducto()
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            DataTable tablaProducto = new DataTable();

            string consulta = @"Select P.Idproducto, P.Codigo, P.Nombre, P.Ganancia, M.IdMarca, M.Nombre , T.IdTipo, T.Nombre from Productos P
                                Left join Marcas M On M.IdMarca = P.IdMarca
                                Left Join Tipos T On T.IdTipo = P.IdTipo";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaProducto.Load(accesoDatos.Lector);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return tablaProducto;

        }
        public DataTable ObtenerProductos()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            DataTable tablaProductos = new DataTable();

            string consulta = "SELECT IdProducto, Nombre FROM Productos";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaProductos.Load(accesoDatos.Lector);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }

            return tablaProductos;
        }

        public decimal ObtenerPrecioProducto(int idProducto)
        {
            decimal precio = 0;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("SELECT Precio FROM Productos WHERE IdProducto = @IdProducto");
                accesoDatos.setearParametro("@IdProducto", idProducto);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    precio = accesoDatos.Lector.GetDecimal(0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el precio del producto: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return precio;
        }


      
    }
}
