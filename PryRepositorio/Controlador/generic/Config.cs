using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PryRepositorio.Controlador.generic
{
    public class Config
    {
        protected static string path = HttpContext.Current.Server.MapPath("");
        protected static string cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Valentina\Downloads\PryRepositorio20181017\PryRepositorio\App_Data\BDRepositorio.mdf;Integrated Security=True";
        protected static SqlConnection con = new SqlConnection(cadena);
    }
}