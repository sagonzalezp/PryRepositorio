using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PryRepositorio
{
    public partial class FormUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            String usr = txtUsuario.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                txtMsg.Visible = true;

                Modelo.Usuario usuario = new Modelo.Usuario();

                usuario.NombreU=txtUsuario.Text;
                usuario.Contrasena = txtPassword.Text;


                if (usuario.IniciarSesion())
                {
                    Session["usuario"] = usuario.NombreU;
                    Session["contra"] = usuario.Contrasena;
                    Session["tipo"] = usuario.Tipo;
                    usuario = null;
                    txtMsg.Text = "Inicio de sesión correcto.";
                    Response.Redirect("FrmInicio.aspx");

                }
                else
                {
                    txtMsg.Text = "Usuario o contraseña incorrecta.";
                }

            }
            catch (Exception ex)
            {
                txtMsg.Text = "Error sistema. Por favor intentelo nuevamente.";
            }
        }
    }
}