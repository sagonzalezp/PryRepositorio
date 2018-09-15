using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Autor
    {
        String codigo;
        String nombre;

        public Autor()
        {
            this.Codigo = "";
            this.Nombre = "";
        }

        public Autor(string codigo, string nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}