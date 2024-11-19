using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCompra
    {
        public void InsertarCompra(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();

          

                // Insertar la compra
                string insertarCompraQuery = "INSERT INTO Compra (IdProveedor, fecha, Precio) " +
                                             "VALUES (@IdProveedor, @fecha, @Precio)";
                datos.setearConsulta(insertarCompraQuery);

                // Configurar parámetros
                datos.setearParametro("@IdProveedor", compra.IdProveedor);
                datos.setearParametro("@fecha", compra.fecha);
                datos.setearParametro("@Precio", compra.Precio);

                datos.ejecutarAccion();
          
            
        }

        // Método para obtener todas las compras
        public List<Compra> ObtenerTodasLasCompras()
        {
            List<Compra> compras = new List<Compra>();
            string consulta = "SELECT idcompra, idproveedor,fecha, costoTotal" +
                              "FROM compra";

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Compra compra = new Compra()
                            {
                                IdCompra = Convert.ToInt32(reader["idcompra"]),
                                IdProveedor = Convert.ToInt32(reader["idproveedor"]),
                               fecha = Convert.ToDateTime(reader["fecha"]),
                                Precio = Convert.ToDecimal(reader["costoTotal"]),
                                
                            };
                            compras.Add(compra);
                        }
                    }
                }
            }

            return compras;
        }

        /*// Método para obtener una compra por su ID
        public Compra ObtenerCompraPorId(int idCompra)
        {
            Compra compra = null;
            string consulta = "SELECT idcompra, idproveedor, idmetododepago, fecha, costoTotal, recibido " +
                              "FROM compra WHERE idcompra = @idcompra";

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@idcompra", idCompra);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            compra = new Compra()
                            {
                                IdCompra = Convert.ToInt32(reader["idcompra"]),
                                IdProveedor = Convert.ToInt32(reader["idproveedor"]),
                                IdMetodoDePago = Convert.ToInt32(reader["idmetododepago"]),
                                FechaCompra = Convert.ToDateTime(reader["fecha"]),
                                CostoTotal = Convert.ToDecimal(reader["costoTotal"]),
                                Recibido = Convert.ToBoolean(reader["recibido"])
                            };
                        }
                    }
                }
            }

            return compra;
        }

        // Método para actualizar una compra (por ejemplo, para marcar como recibida)
        public void ActualizarCompra(Compra compra)
        {
            string consulta = "UPDATE compra SET idproveedor = @idproveedor, idmetododepago = @idmetododepago, " +
                              "fecha = @fecha, costoTotal = @costoTotal, recibido = @recibido " +
                              "WHERE idcompra = @idcompra";

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@idcompra", compra.IdCompra);
                    cmd.Parameters.AddWithValue("@idproveedor", compra.IdProveedor);
                    cmd.Parameters.AddWithValue("@idmetododepago", compra.IdMetodoDePago);
                    cmd.Parameters.AddWithValue("@fecha", compra.FechaCompra);
                    cmd.Parameters.AddWithValue("@costoTotal", compra.CostoTotal);
                    cmd.Parameters.AddWithValue("@recibido", compra.Recibido);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar una compra por su ID
        public void EliminarCompra(int idCompra)
        {
            string consulta = "DELETE FROM compra WHERE idcompra = @idcompra";

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@idcompra", idCompra);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }*/
    }
}
