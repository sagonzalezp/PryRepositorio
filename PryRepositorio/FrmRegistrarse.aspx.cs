using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PryRepositorio
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                txtMsg.Visible = true;

                Modelo.Usuario usuario = new Modelo.Usuario();


                if(txtUser.Text =="" || txtPassword.Text=="" || txtPassword2.Text =="")
                {
                    txtMsg.Text = "Por favor ingrese todos los datos.";
                }
                else
                {
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        usuario.NombreU=(txtUser.Text);
                        usuario.Contrasena=(txtPassword.Text);
                        usuario.Tipo=("usuario");

                        if (usuario.ValidarUsuario())
                        {
                            txtMsg.Text = "Este usuario ya esta registrado. Intente con otro.";
                        }
                        else
                        {
                            if (usuario.RegistrarUsuario())
                            {
                                txtMsg.Text = "Registro exitoso";
                            }
                            else
                            {
                                txtMsg.Text = "Error al registrar el usuario";
                            }
                        }
                    }
                    else
                    {
                        txtMsg.Text = "Las contraseñas no coinciden.";
                    }
                }
            }
            catch(Exception ex)
            {
                txtMsg.Text = "Error del sistema.";
            }
        }
    }
}