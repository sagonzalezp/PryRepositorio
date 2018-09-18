using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PryRepositorio.Controlador;
using System.Data.SqlClient;
using System.Data;

namespace PryRepositorio
   
{
    public partial class FrmArea1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
                String idArea = txtArea.Text;
                String nombre = txtNombre.Text;
                String fkidArea= txtFkarea.Text;
                String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"C:\Users\González Peña\source\repos\BSD_Facturas_20180803\BSD_Facturas_20180803\DBFACTURAS.mdf" + @";Integrated Security=True";
                //String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
                //String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("procInsertArea", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@fkArea", SqlDbType.VarChar, 10);
            
                cmd.Parameters["@idArea"].Value = idArea;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@fkArea"].Value = fkidArea;
            
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
                catch(Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                String idArea = txtArea.Text;
                String nombre = txtNombre.Text;
                String fkidArea = txtFkarea.Text;
                String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\González Peña\source\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security=True";
                //String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("procModificarArea", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@fkArea", SqlDbType.VarChar, 10);

                cmd.Parameters["@idArea"].Value = idArea;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@fkArea"].Value = fkidArea;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            { 
                String idArea = txtArea.Text;
                String nombre = txtNombre.Text;
                String fkidArea = txtFkarea.Text;
                String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\González Peña\source\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security=True";
                //String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("procConsultarArea", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters["@idArea"].Value = idArea;
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet objDs = new DataSet();
                da.Fill(objDs);
                txtNombre.Text= objDs.Tables[0].Rows[0][0].ToString();
                txtFkarea.Text = objDs.Tables[0].Rows[0][1].ToString();
                cnn.Close();
            }
                catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            { 
                String idArea = txtArea.Text;
                String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\González Peña\source\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security=True";
                //String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("procBorrarArea", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters["@idArea"].Value = idArea;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }
    }
}