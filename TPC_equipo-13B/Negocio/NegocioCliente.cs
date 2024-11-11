using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCliente
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioCliente()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        // Agregar cliente
        public void AgregarCliente(Cliente cliente)
        {
            string consulta = "INSERT INTO Clientes (Nombre, Apellido, DNI, Telefono, Celular, Email, Direccion, Provincia, Pais) " +
                              "VALUES (@Nombre, @Apellido, @DNI, @Telefono, @Celular, @Email, @Direccion, @Provincia, @Pais)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", cliente.Nombre);
            accesoDatos.setearParametro("@Apellido", cliente.Apellido);
            accesoDatos.setearParametro("@DNI", cliente.DNI);
            accesoDatos.setearParametro("@Telefono", cliente.Telefono);
            accesoDatos.setearParametro("@Celular", cliente.Celular);
            accesoDatos.setearParametro("@Email", cliente.Email);
            accesoDatos.setearParametro("@Direccion", cliente.Direccion);
            accesoDatos.setearParametro("@Provincia", cliente.Provincia);
            accesoDatos.setearParametro("@Pais", cliente.Pais);

            accesoDatos.ejecutarAccion();
        }

        // Modificar existente
        public void ModificarCliente(Cliente cliente)
        {
            string consulta = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Telefono = @Telefono, " +
                              "Celular = @Celular, Email = @Email, Direccion = @Direccion, Provincia = @Provincia, Pais = @Pais " +
                              "WHERE ID = @ID";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@ID", cliente.ID);
            accesoDatos.setearParametro("@Nombre", cliente.Nombre);
            accesoDatos.setearParametro("@Apellido", cliente.Apellido);
            accesoDatos.setearParametro("@DNI", cliente.DNI);
            accesoDatos.setearParametro("@Telefono", cliente.Telefono);
            accesoDatos.setearParametro("@Celular", cliente.Celular);
            accesoDatos.setearParametro("@Email", cliente.Email);
            accesoDatos.setearParametro("@Direccion", cliente.Direccion);
            accesoDatos.setearParametro("@Provincia", cliente.Provincia);
            accesoDatos.setearParametro("@Pais", cliente.Pais);

            accesoDatos.ejecutarAccion();
        }

        // Eliminar cliente
        public void EliminarCliente(int idCliente)
        {
            string consulta = "DELETE FROM Clientes WHERE ID = @ID";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@ID", idCliente);

            accesoDatos.ejecutarAccion();
        }

        // Buscar clientes
        public DataTable BuscarClientes(string nombre = null, string apellido = null, int? dni = null, string telefono = null, string celular = null, string email = null, string direccion = null, string provincia = null, string pais = null)
        {
            string consulta = "SELECT * FROM Clientes WHERE 1=1";

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                consulta += " AND Apellido LIKE @Apellido";
                accesoDatos.setearParametro("@Apellido", "%" + apellido + "%");
            }

            if (dni.HasValue)
            {
                consulta += " AND DNI = @DNI";
                accesoDatos.setearParametro("@DNI", dni.Value);
            }

            if (!string.IsNullOrEmpty(telefono))
            {
                consulta += " AND Telefono LIKE @Telefono";
                accesoDatos.setearParametro("@Telefono", "%" + telefono + "%");
            }

            if (!string.IsNullOrEmpty(celular))
            {
                consulta += " AND Celular LIKE @Celular";
                accesoDatos.setearParametro("@Celular", "%" + celular + "%");
            }

            if (!string.IsNullOrEmpty(email))
            {
                consulta += " AND Email LIKE @Email";
                accesoDatos.setearParametro("@Email", "%" + email + "%");
            }

            if (!string.IsNullOrEmpty(direccion))
            {
                consulta += " AND Direccion LIKE @Direccion";
                accesoDatos.setearParametro("@Direccion", "%" + direccion + "%");
            }

            if (!string.IsNullOrEmpty(provincia))
            {
                consulta += " AND Provincia LIKE @Provincia";
                accesoDatos.setearParametro("@Provincia", "%" + provincia + "%");
            }

            if (!string.IsNullOrEmpty(pais))
            {
                consulta += " AND Pais LIKE @Pais";
                accesoDatos.setearParametro("@Pais", "%" + pais + "%");
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable clientes = new DataTable();
            clientes.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return clientes;
        }
        public DataTable ObtenerClientes()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            DataTable tablaClientes = new DataTable();

            string consulta = "SELECT IdCliente, Nombre FROM Clientes"; 
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaClientes.Load(accesoDatos.Lector);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }

            return tablaClientes;
        }
    }
}
