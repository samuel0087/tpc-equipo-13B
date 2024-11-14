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

        public void AgregarProveedor(Proveedor proveedor)
        {
            string consulta = "INSERT INTO Provedores (Nombre, Apellido, Email, Telefono, Celular, Direccion, Provincia, Pais) " +
                              "VALUES (@Nombre, @Apellido, @Email, @Telefono, @Celular, @Direccion, @Provincia, @Pais)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre",proveedor.Nombre);
            accesoDatos.setearParametro("@Apellido",proveedor.Apellido);
            accesoDatos.setearParametro("@Email",proveedor.Email);
            accesoDatos.setearParametro("@Telefono", int.Parse(proveedor.Telefono));
            accesoDatos.setearParametro("@Celular", int.Parse(proveedor.Celular));
            accesoDatos.setearParametro("@Direccion", proveedor.Direccion);
            accesoDatos.setearParametro("@Provincia", proveedor.Provincia);
            accesoDatos.setearParametro("@Pais",proveedor.Pais);
            accesoDatos.ejecutarAccion();
        }

        //modificar proveedor
     
        public void ModificarProveedor(Proveedor proveedor)
        {
            string consulta = "UPDATE Provedores SET Nombre = @Nombre,Apellido = @Apellido,Email = @Email,Telefono = @Telefono,Celular = @Celular,Direccion = @Direccion,Provincia = @Provincia,Pais = @Pais WHERE IdProveedor = @IdProveedor;";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProveedor",proveedor.IdProveedor);
            accesoDatos.setearParametro("@Nombre", proveedor.Nombre);
            accesoDatos.setearParametro("@Apellido",proveedor.Apellido);
            accesoDatos.setearParametro("@Email",proveedor.Email);
            accesoDatos.setearParametro("@Telefono",proveedor.Telefono);
            accesoDatos.setearParametro("@Celular",proveedor.Celular);
            accesoDatos.setearParametro("@Direccion",proveedor.Direccion);
            accesoDatos.setearParametro("@Provincia",proveedor.Provincia);
            accesoDatos.setearParametro("@Pais",proveedor.Pais);

            accesoDatos.ejecutarAccion();
        }

        //eliminar proveedor
        public void EliminarProveedor(int idProveedor)
        {
            string consulta = "DELETE FROM Provedores WHERE IdProveedor = @IdProveedor";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdProveedor", idProveedor);

            accesoDatos.ejecutarAccion();
        }

        //buscar proveedores
        public DataTable BuscarProveedores(string nombre = null, string apellido = null, string email = null, string telefono = null, string celular = null, string direccion = null, string provincia = null, string pais = null)
        {
            string consulta = "SELECT * FROM Provedores WHERE 1=1";

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
        //Busacar Proveedor por id:
        public Proveedor buscarProveedorPorId(int id)
        {
            Proveedor aux = new Proveedor();
            string consulta = "SELECT IdProveedor,Nombre,Apellido,Email,Telefono,Celular,Direccion,Provincia,Pais FROM Provedores WHERE IdProveedor = @id;";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@id", id);

            accesoDatos.ejecutarLectura();

            if (accesoDatos.Lector.Read())
            {
                aux.IdProveedor = accesoDatos.Lector.GetInt32(0);
                aux.Nombre = accesoDatos.Lector.GetString(1);
                aux.Apellido= accesoDatos.Lector.GetString(2);
                aux.Email = accesoDatos.Lector.GetString(3);
                aux.Telefono = accesoDatos.Lector.IsDBNull(4)? null: accesoDatos.Lector.GetInt32(4).ToString();
                aux.Celular = accesoDatos.Lector.IsDBNull(5)? null: accesoDatos.Lector.GetInt32(5).ToString();
                aux.Direccion= accesoDatos.Lector.GetString(6);
                aux.Provincia = accesoDatos.Lector.GetString(7);
                aux.Pais = accesoDatos.Lector.GetString(8);
            }

            accesoDatos.cerrarConexion();
            return aux;
        }

        public DataTable ObtenerProveedores()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            DataTable tablaProveedores = new DataTable();

            string consulta = "SELECT IdProveedor, Nombre, Apellido FROM Provedores";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablaProveedores.Load(accesoDatos.Lector);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener proveedores: " + ex.Message);
            }

            return tablaProveedores;
        }

    }
}
