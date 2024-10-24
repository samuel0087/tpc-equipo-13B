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
    public class NegocioProveedor
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioProveedor()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        //nuevo proveedor
        public void AgregarProveedor(string nombre, string apellido, string email, string telefono, string celular, string direccion, string provincia, string pais)
        {
            string consulta = "INSERT INTO Proveedores (Nombre, Apellido, Email, Telefono, Celular, Direccion, Provincia, Pais) " +
                              "VALUES (@Nombre, @Apellido, @Email, @Telefono, @Celular, @Direccion, @Provincia, @Pais)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", nombre);
            accesoDatos.setearParametro("@Apellido", apellido);
            accesoDatos.setearParametro("@Email", email);
            accesoDatos.setearParametro("@Telefono", telefono);
            accesoDatos.setearParametro("@Celular", celular);
            accesoDatos.setearParametro("@Direccion", direccion);
            accesoDatos.setearParametro("@Provincia", provincia);
            accesoDatos.setearParametro("@Pais", pais);

            accesoDatos.ejecutarAccion();
        }

        //modificar proveedor
        public void ModificarProveedor(int idProveedor, string nombre, string apellido, string email, string telefono, string celular, string direccion, string provincia, string pais)
        {
            string consulta = "UPDATE Proveedores SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, " +
                              "Celular = @Celular, Direccion = @Direccion, Provincia = @Provincia, Pais = @Pais " +
                              "WHERE IdProveedor = @IdProveedor";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProveedor", idProveedor);
            accesoDatos.setearParametro("@Nombre", nombre);
            accesoDatos.setearParametro("@Apellido", apellido);
            accesoDatos.setearParametro("@Email", email);
            accesoDatos.setearParametro("@Telefono", telefono);
            accesoDatos.setearParametro("@Celular", celular);
            accesoDatos.setearParametro("@Direccion", direccion);
            accesoDatos.setearParametro("@Provincia", provincia);
            accesoDatos.setearParametro("@Pais", pais);

            accesoDatos.ejecutarAccion();
        }

        //eliminar proveedor
        public void EliminarProveedor(int idProveedor)
        {
            string consulta = "DELETE FROM Proveedores WHERE IdProveedor = @IdProveedor";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProveedor", idProveedor);

            accesoDatos.ejecutarAccion();
        }

        //buscar proveedores
        public DataTable BuscarProveedores(string nombre = null, string apellido = null, string email = null, string telefono = null, string celular = null, string direccion = null, string provincia = null, string pais = null)
        {
            string consulta = "SELECT * FROM Proveedores WHERE 1=1";

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

            if (!string.IsNullOrEmpty(email))
            {
                consulta += " AND Email LIKE @Email";
                accesoDatos.setearParametro("@Email", "%" + email + "%");
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

            DataTable proveedores = new DataTable();
            proveedores.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return proveedores;
        }
        public DataTable cargartablaProveedor()
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            DataTable tablaProveedor = new DataTable();

            string consulta = "SELECT  IdProveedor,Nombre,Apellido,Email,Telefono,Celular,Direccion,Provincia,Pais FROM  Provedores;";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaProveedor.Load(accesoDatos.Lector);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return tablaProveedor;

        }
    }
}
