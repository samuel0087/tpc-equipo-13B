using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMetodoPago
    {

        public List<MetodoDePago> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<MetodoDePago> lista = new List<MetodoDePago>();
            string consulta = @"SELECT IdMetodoDePago, Nombre FROM MetodoDePago";
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MetodoDePago aux = new MetodoDePago();
                    aux.IdMetodoDePago = datos.Lector["IdMetodoDePago"] is DBNull ? 0 : (int)datos.Lector["IdMetodoDePago"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
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
                datos.cerrarConexion();
            }
        }
    }
}
