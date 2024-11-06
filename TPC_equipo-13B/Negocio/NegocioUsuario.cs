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

        //Buscar usuario para logear
        public bool loguear(Usuario usuario)
        {
            try
            {
                accesoDatos.setearConsulta(@"Select U.IdUsuario, R.IdRol, R.Rol
                                            From Usuarios U 
                                            Inner Join Roles R On U.IdRol = R.IdRol
                                            Where U.Nombre = @Nombre
                                            And U.Contraseña = @Password");
                accesoDatos.setearParametro("@Nombre", usuario.Nombre);
                accesoDatos.setearParametro("@Password", usuario.Contraseña);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    usuario.IdUsuario = accesoDatos.Lector["IdUsuario"] is DBNull ? 0 : (int)accesoDatos.Lector["IdUsuario"];

                    usuario.Rol = new Rol();
                    usuario.Rol.IdRol = accesoDatos.Lector["IdRol"] is DBNull ? 0 : (int)accesoDatos.Lector["IdRol"];
                    usuario.Rol.NombreRol = accesoDatos.Lector["Rol"] is DBNull ? "" : (string)accesoDatos.Lector["Rol"];
                    
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

        }


        // Agregar usuario
   
        public void AgregarUsuario(Usuario usuario)
        {
            string consulta = "INSERT INTO Usuarios (Nombre, Contraseña, IdRol) VALUES (@Nombre, @Contraseña, @IdRol)"; // Cambia @Rol por @IdRol

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@Nombre", usuario.Nombre);
            accesoDatos.setearParametro("@Contraseña", usuario.Contraseña);
            accesoDatos.setearParametro("@IdRol", usuario.Rol.IdRol);  

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
            Usuario aux = new Usuario(); 
            string consulta = "SELECT U.idusuario, U.nombre, U.Contraseña, U.IdRol, R.Rol AS NombreRol " +
                              "FROM usuarios U INNER JOIN Roles R ON U.IdRol = R.IdRol WHERE U.idusuario = @id";

            accesoDatos.setearConsulta(consulta);
            accesoDatos.setearParametro("@id", id);

            accesoDatos.ejecutarLectura();

            if (accesoDatos.Lector.Read())
            {
                aux.IdUsuario = accesoDatos.Lector.GetInt32(0);
                aux.Nombre = accesoDatos.Lector.GetString(1);
                aux.Contraseña = accesoDatos.Lector.GetString(2);
                aux.Rol = new Rol(); 
                aux.Rol.IdRol = accesoDatos.Lector.GetInt32(3);
                aux.Rol.NombreRol = accesoDatos.Lector.GetString(4);
            }

            accesoDatos.cerrarConexion();
            return aux;
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

            //se comenta, ya que tiene un IdRol(int)
            //if (!string.IsNullOrEmpty(rol))
            //{
            //    consulta += " AND Rol LIKE @Rol";
            //    accesoDatos.setearParametro("@Rol", "%" + rol + "%");
            //}

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

            string consulta = @"select U.IdUsuario, U.Nombre, U.Contraseña, R.IdRol, R.Rol from Usuarios U
                                Inner Join Roles R On R.IdRol = U.IdRol";
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
