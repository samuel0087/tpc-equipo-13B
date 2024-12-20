﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Acceso_Datos;

namespace Negocio
{
    public class NegocioRol
    {
        public List<Rol> listar()
        {
			List<Rol> lista = new List<Rol>();
			AccesoDatos datos = new AccesoDatos();

			string consulta = "Select IdRol,Rol From Roles";
			try
			{
				datos.setearConsulta(consulta);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Rol aux = new Rol();
					aux.IdRol = datos.Lector["IdRol"] is DBNull ? 0 : (int)datos.Lector["IdRol"];
					aux.NombreRol = datos.Lector["Rol"] is DBNull ? "" : (string)datos.Lector["Rol"];

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

			}

        }
    }
}
