using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace PryRepositorio.Controlador
{
    public class ControlLogin
    {
        public bool IniciarSesion()
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            Connetion.Connection con = new Connetion.Connection();
            SqlCommand com = new SqlCommand();


            try
            {
                con.OpenSqlConnection();
                com.Connection = con.Conexion();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Inicio_Sesion";
                com.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario.NombreU;
                com.Parameters.Add("@contraseña", SqlDbType.NVarChar).Value = usuario.Contrasena;
                SqlDataReader reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    usuario.NombreU=(reader["nombreUsr"].ToString());
                    usuario.Contrasena=(reader["contrasena"].ToString());
                    usuario.Tipo=(reader["tipo"].ToString());
            
                    reader.Close();
                    reader = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                con.CloseSqlConnection();
                usuario = null;
                com = null;
                con = null;
            }
        }


        public bool ValidarUsuario()
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            Connetion.Connection con = new Connetion.Connection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter dt = new SqlDataAdapter();
            DataTable tabla = new DataTable();

            try
            {

                con.OpenSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter("ValidarUsuario", con.Conexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario.NombreU;
                da.Fill(tabla);

                if (tabla.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.CloseSqlConnection();
                cmd = null;
                usuario = null;
                dt = null;
                tabla = null;
            }
        }


        public bool Registrar()
        {
            Modelo.Usuario usuario = new Modelo.Usuario();
            Connetion.Connection con = new Connetion.Connection();
            SqlCommand cmd = new SqlCommand();

            try
            {

                con.OpenSqlConnection();
                cmd.Connection = con.Conexion();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "procRegistrarUsr";
                cmd.Parameters.Add("@nombreUsr", SqlDbType.VarChar).Value = usuario.NombreU;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = usuario.Contrasena;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = usuario.Tipo;

                int reader = cmd.ExecuteNonQuery();

                if (reader > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.CloseSqlConnection();
                cmd = null;
                usuario = null;
            }
        }

    }
       
}
