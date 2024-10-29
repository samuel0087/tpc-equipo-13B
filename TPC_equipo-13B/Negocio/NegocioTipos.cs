using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioTipo
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioTipo()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        public List<Tipo> listar()
        {
            List<Tipo> lista = new List<Tipo>();
            string consulta = @"SELECT IdTipo, Nombre FROM Tipos";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IdTipo = accesoDatos.Lector["IdTipo"] is DBNull ? 0 : (int)accesoDatos.Lector["IdTipo"];
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

        public List<Tipo> listar(bool orden)
        {
            List<Tipo> lista = new List<Tipo>();
            string consulta = @"SELECT IdTipo, Nombre FROM Tipos ORDER BY Nombre ASC";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.IdTipo = accesoDatos.Lector["IdTipo"] is DBNull ? 0 : (int)accesoDatos.Lector["IdTipo"];
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

        // Agregar tipo
        public void AgregarTipo(Tipo aux)
        {
            string consulta = "INSERT INTO Tipos (Nombre) VALUES (@Nombre)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", aux.Nombre);

            accesoDatos.ejecutarAccion();
        }

        // Modificar tipo
        public void ModificarTipo(Tipo aux)
        {
            string consulta = "UPDATE Tipos SET Nombre = @Nombre WHERE IdTipo = @IdTipo";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdTipo", aux.IdTipo);
            accesoDatos.setearParametro("@Nombre", aux.Nombre);

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
        public DataTable cargartablaTipos()
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            DataTable tablaTipos = new DataTable();

            string consulta = "SELECT  IdTipo,Nombre FROM  Tipos;";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaTipos.Load(accesoDatos.Lector);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return tablaTipos;

        }

        //Buscar una sola marca
        public Tipo getOne(int id)
        {
            Tipo aux = new Tipo();
            string consulta = "SELECT IdTipo, Nombre FROM Tipos WHERE IdTipo = @Id";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@Id", id);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux.IdTipo = accesoDatos.Lector["IdTipo"] is DBNull ? 0 : (int)accesoDatos.Lector["IdTipo"];
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

        public Tipo getOneByNombre(string nombre)
        {
            Tipo aux = new Tipo();
            string consulta = "SELECT IdTipo, Nombre FROM Tipos WHERE Nombre = @nombre";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametro("@nombre", nombre);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    aux.IdTipo = accesoDatos.Lector["IdTipo"] is DBNull ? 0 : (int)accesoDatos.Lector["IdTipo"];
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
