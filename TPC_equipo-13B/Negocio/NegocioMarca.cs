using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

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
        public void AgregarMarca(Marca aux)
        {
            string consulta = "INSERT INTO Marcas (Nombre) VALUES (@Nombre)";

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

        // Modificar marca
        public void ModificarMarca(Marca aux)
        {
            string consulta = "UPDATE Marcas SET Nombre = @Nombre WHERE IdMarca = @IdMarca";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@IdMarca", aux.IdMarca);
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

        // Eliminar marca
        public void EliminarMarca(Marca aux)
        {
            string consulta = "DELETE FROM Marcas WHERE IdMarca = @IdMarca";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdMarca", aux.IdMarca);

            accesoDatos.ejecutarAccion();
        }

        // Buscar marcas
        public Marca BuscarMarca(string nombre = null, int? idMarca = null)
        {
            string consulta = "SELECT * FROM Marcas WHERE 1=1";
            Marca aux = null;

            try
            {
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

                if (accesoDatos.Lector.Read())
                {
                    aux = new Marca();
                    aux.IdMarca = accesoDatos.Lector["IdMarca"] is DBNull ? 0 : (int)accesoDatos.Lector["IdMarca"];
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

        //Buscar una sola marca
        public Marca getOne(int id)
        {
            Marca aux = new Marca();
            string consulta = "SELECT IdMarca, Nombre FROM Marcas WHERE IdMarca = @Id";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@Id", id);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux.IdMarca = accesoDatos.Lector["IdMarca"] is DBNull ? 0 : (int)accesoDatos.Lector["IdMarca"];
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

            }
        }
    }
}
