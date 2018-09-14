using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Usuario
    {
        String nombreUsr;
        String contrasena;
        String tipo;

        public Usuario(string nombreUsr, string contrasena, string tipo)
        {
            this.nombreUsr = nombreUsr;
            this.contrasena = contrasena;
            this.tipo = tipo;
        }

        public string NombreUsr { get => nombreUsr; set => nombreUsr = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}