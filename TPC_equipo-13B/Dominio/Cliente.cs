﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int ID {  get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }
        public int DNI {  get; set; }
        public string Telefono {  get; set; }

        public string Celular { get; set; }
        public string Email {  get; set; }
        public string Direccion {  get; set; }
        public string Provincia {  get; set; }
        public string Pais {  get; set; }

    }
}
