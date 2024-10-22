using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        private Acceso_Datos.AccesoDatos accesoDatos;

        public NegocioUsuario()
        {
            accesoDatos = new Acceso_Datos.AccesoDatos();
        }

        // Agregar usuario
        public void AgregarUsuario(Usuario usuario)
        {
            string consulta = "INSERT INTO Usuarios (Nombre, Contraseña, Rol) VALUES (@Nombre, @Contraseña, @Rol)";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", usuario.Nombre);
            accesoDatos.setearParametro("@Contraseña", usuario.Contraseña);
            accesoDatos.setearParametro("@Rol", usuario.Rol);

            accesoDatos.ejecutarAccion();
        }

        // Modificar usuario
        public void ModificarUsuario(Usuario usuario)
        {
            string consulta = "UPDATE Usuarios SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol WHERE IdUsuario = @IdUsuario";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdUsuario", usuario.IdUsuario);
            accesoDatos.setearParametro("@Nombre", usuario.Nombre);
            accesoDatos.setearParametro("@Contraseña", usuario.Contraseña);
            accesoDatos.setearParametro("@Rol", usuario.Rol);

            accesoDatos.ejecutarAccion();
        }
        public Usuario buscarUsuarioPorId(int id)
        {
            Usuario usuario = null;
            string consulta = "SELECT idusuario, nombre,Contraseña,rol FROM usuarios WHERE idusuario = @id";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@id", id);

            accesoDatos.ejecutarLectura();

            if (accesoDatos.Lector.Read())
            {
                usuario = new Usuario
                {
                    IdUsuario = accesoDatos.Lector.GetInt32(0),
                    Nombre = accesoDatos.Lector.GetString(1),
                    Contraseña = accesoDatos.Lector.GetString(2),
                    Rol = accesoDatos.Lector.GetString(3),
                };
            }

            accesoDatos.cerrarConexion(); 
            return usuario; 
        }
        // Eliminar usuario
        public void EliminarUsuario(int idUsuario)
        {
            string consulta = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@IdUsuario", idUsuario);

            accesoDatos.ejecutarAccion();
        }

        // Buscar usuarios
        public DataTable BuscarUsuarios(int? idUsuario = null, string nombre = null, string rol = null)
        {
            string consulta = "SELECT * FROM Usuarios WHERE 1=1";

            if (idUsuario.HasValue)
            {
                consulta += " AND IdUsuario = @IdUsuario";
                accesoDatos.setearParametro("@IdUsuario", idUsuario.Value);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " AND Nombre LIKE @Nombre";
                accesoDatos.setearParametro("@Nombre", "%" + nombre + "%");
            }

            if (!string.IsNullOrEmpty(rol))
            {
                consulta += " AND Rol LIKE @Rol";
                accesoDatos.setearParametro("@Rol", "%" + rol + "%");
            }

            accesoDatos.setearConsulta(consulta);
            accesoDatos.ejecutarLectura();

            DataTable usuarios = new DataTable();
            usuarios.Load(accesoDatos.Lector);
            accesoDatos.cerrarConexion();

            return usuarios;
        }
        //Esta es para cargar tablas
        public DataTable cargartablausuario()
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            DataTable tablausuarios = new DataTable();

            string consulta = "select IdUsuario,Nombre,Contraseña,Rol from Usuarios ";
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.ejecutarLectura();
                tablausuarios.Load(accesoDatos.Lector);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return tablausuarios;

        }
    }
}
