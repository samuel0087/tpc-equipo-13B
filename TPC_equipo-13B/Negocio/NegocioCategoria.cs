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

        // Agregar categoría
        public void AgregarCategoria(string nombre)
        {
            string consulta = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Modificar categoría
        public void ModificarCategoria(int idCategoria, string nombre)
        {
            string consulta = "UPDATE Categorias SET Nombre = @Nombre WHERE IdCategoria = @IdCategoria";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdCategoria", idCategoria);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar categoría
        public void EliminarCategoria(int idCategoria)
        {
            string consulta = "DELETE FROM Categorias WHERE IdCategoria = @IdCategoria";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdCategoria", idCategoria);

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
    }
}
