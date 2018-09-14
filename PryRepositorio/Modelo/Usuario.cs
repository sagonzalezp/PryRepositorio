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
        String nivelAccesso;

        public Usuario(string nombreUsr, string contrasena, string nivelAccesso)
        {
            this.nombreUsr = nombreUsr;
            this.contrasena = contrasena;
            this.nivelAccesso = nivelAccesso;
        }

        public string NombreUsr { get => nombreUsr; set => nombreUsr = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string NivelAccesso { get => nivelAccesso; set => nivelAccesso = value; }
    }
}