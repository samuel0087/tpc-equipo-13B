using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMarca
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioMarca()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        // Agregar marca
        public void AgregarMarca(string nombre)
        {
            string consulta = "INSERT INTO Marcas (Nombre) VALUES (@Nombre)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Modificar marca
        public void ModificarMarca(int idMarca, string nombre)
        {
            string consulta = "UPDATE Marcas SET Nombre = @Nombre WHERE IdMarca = @IdMarca";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdMarca", idMarca);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar marca
        public void EliminarMarca(int idMarca)
        {
            string consulta = "DELETE FROM Marcas WHERE IdMarca = @IdMarca";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdMarca", idMarca);

            accesoDatos.ejecutarAccion();
        }

        // Buscar marcas
        public DataTable BuscarMarcas(string nombre = null, int? idMarca = null)
        {
            string consulta = "SELECT * FROM Marcas WHERE 1=1";

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (idMarca.HasValue)
            {
                consulta += " AND IdMarca = @IdMarca";
                accesoDatos.setearParametro("@IdMarca", idMarca.Value);
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable marcas = new DataTable();
            marcas.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return marcas;
        }
    }
}
