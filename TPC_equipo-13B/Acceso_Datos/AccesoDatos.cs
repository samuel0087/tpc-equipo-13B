using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Acceso_Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        //se crea la conexxion a la base de datos en el constructor
        public AccesoDatos()
        {
            const string DB = "TP_Cuatrimestral"; //Nombre de la base de datos
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database="+ DB +"; integrated security=true");
            comando = new SqlCommand();
        }

        //Recibe la consulta SQL
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //Ejecuta la consulta Sql y guarda el resultado en el lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //ejecuta una accion en la base de datos
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void cerrarConexion()
        {
            try
            {
                if (lector != null && !lector.IsClosed)
                {
                    lector.Close();
                }
                if (conexion != null && conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, si es necesario
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }

        public object ejecutarAccionEscalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }
    }
}
