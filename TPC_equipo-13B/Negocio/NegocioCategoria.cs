using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCategoria
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioCategoria()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            string consulta = @"SELECT IdCategoria, Nombre FROM Categorias";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = accesoDatos.Lector["IdCategoria"] is DBNull ? 0 : (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = accesoDatos.Lector["Nombre"] is DBNull ? "" : (string)accesoDatos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
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

        public List<Categoria> listar(bool orden)
        {
            List<Categoria> lista = new List<Categoria>();
            string consulta = @"SELECT IdCategoria, Nombre FROM Categorias ORDER BY Nombre ASC";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = accesoDatos.Lector["IdCategoria"] is DBNull ? 0 : (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = accesoDatos.Lector["Nombre"] is DBNull ? "" : (string)accesoDatos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
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

        // Agregar categoría
        public void AgregarCategoria(Categoria aux)
        {
            string consulta = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";

            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@Nombre", aux.Nombre);

                accesoDatos.ejecutarAccion();
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

        // Modificar categoría
        public void ModificarCategoria(Categoria aux)
        {
            string consulta = "UPDATE Categorias SET Nombre = @Nombre WHERE IdCategoria = @IdCategoria";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@IdCategoria", aux.IdCategoria);
                accesoDatos.setearParametro("@Nombre", aux.Nombre);

                accesoDatos.ejecutarAccion();
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

        // Eliminar categoría
        public void EliminarCategoria(Categoria aux)
        {
            string consulta = "DELETE FROM Categorias WHERE IdCategoria = @IdCategoria";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdCategoria", aux.IdCategoria);

            accesoDatos.ejecutarAccion();
        }

        // Buscar categorías
        public DataTable BuscarCategorias(string nombre = null, int? idCategoria = null)
        {
            string consulta = "SELECT * FROM Categorias WHERE 1=1";

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (idCategoria.HasValue)
            {
                consulta += " AND IdCategoria = @IdCategoria";
                accesoDatos.setearParametro("@IdCategoria", idCategoria.Value);
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable categorias = new DataTable();
            categorias.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return categorias;
        }

        public Categoria getOne(int id)
        {
            Categoria aux = new Categoria();
            string consulta = "SELECT IdCategoria, Nombre FROM Categorias WHERE IdCategoria = @Id";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@Id", id);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux.IdCategoria = accesoDatos.Lector["IdCategoria"] is DBNull ? 0 : (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = accesoDatos.Lector["Nombre"] is DBNull ? "" : (string)accesoDatos.Lector["Nombre"];
                }

                return aux;

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


        public Categoria getOneByNombre(string nombre)
        {
            Categoria aux = new Categoria();
            string consulta = "SELECT IdCategoria, Nombre FROM Categorias WHERE Nombre = @nombre";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@nombre", nombre);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux.IdCategoria = accesoDatos.Lector["IdCategoria"] is DBNull ? 0 : (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = accesoDatos.Lector["Nombre"] is DBNull ? "" : (string)accesoDatos.Lector["Nombre"];
                }

                return aux;

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
    }
}
