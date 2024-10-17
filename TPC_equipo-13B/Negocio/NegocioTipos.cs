using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTipo
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioTipo()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        // Agregar tipo
        public void AgregarTipo(string nombre)
        {
            string consulta = "INSERT INTO Tipos (Nombre) VALUES (@Nombre)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Modificar tipo
        public void ModificarTipo(int idTipo, string nombre)
        {
            string consulta = "UPDATE Tipos SET Nombre = @Nombre WHERE IdTipo = @IdTipo";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdTipo", idTipo);
            accesoDatos.setearParametro("@Nombre", nombre);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar tipo
        public void EliminarTipo(int idTipo)
        {
            string consulta = "DELETE FROM Tipos WHERE IdTipo = @IdTipo";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdTipo", idTipo);

            accesoDatos.ejecutarAccion();
        }

        // Buscar tipos
        public DataTable BuscarTipos(string nombre = null, int? idTipo = null)
        {
            string consulta = "SELECT * FROM Tipos WHERE 1=1";

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (idTipo.HasValue)
            {
                consulta += " AND IdTipo = @IdTipo";
                accesoDatos.setearParametro("@IdTipo", idTipo.Value);
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable tipos = new DataTable();
            tipos.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return tipos;
        }
    }
}
