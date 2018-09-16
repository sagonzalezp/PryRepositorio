using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Lo uso para crear el metodo ejecutarConsulta que retorna un DataSet

namespace PryRepositorio.Controlador
{
    class Conexion
    {
        String cadenaConexion;
        SqlConnection objConnection;
        SqlCommand objCommand;
        SqlDataAdapter objAdapter;
        
        String mensaje;

        public Conexion()
        {
            this.cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf;Integrated Security=True";
            this.objConnection = new SqlConnection(cadenaConexion);
            this.objCommand = null;
            this.objAdapter = null;
        }

        public Conexion(SqlConnection objConnection, SqlCommand objCommand, SqlDataAdapter objAdapter, string cadenaConexion, string mensaje)
        {
            this.objConnection = objConnection;
            this.objCommand = objCommand;
            this.objAdapter = objAdapter;
            this.cadenaConexion = cadenaConexion;
            this.mensaje = mensaje;
        }

        public SqlConnection ObjConnection { get => objConnection; set => objConnection = value; }
        public SqlCommand ObjCommand { get => objCommand; set => objCommand = value; }
        public SqlDataAdapter ObjAdapter { get => objAdapter; set => objAdapter = value; }
        public String CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }
        public String Mensaje { get => mensaje; set => mensaje = value; }

        

        public String abrirConexion()
        {
            
            try
            {
                objConnection = new SqlConnection(CadenaConexion);//declarando clase
                objConnection.Open();

            }
            catch (Exception objExp)
            {
                mensaje = objExp.Message;
            }

            return mensaje;
        }


        public String CerrarConexion()
        {
            
            try
            {
                objConnection.Close();

            }
            catch (Exception objExp)
            {
                mensaje = objExp.Message;
            }

            return mensaje;
        }

        public String ejecutarComandoSql(String comandoSql)//parametro  variable que recibe
        {
            
            try
            {
               
                ObjCommand = new SqlCommand(comandoSql, objConnection);//argumento dato que se envia
                ObjCommand.ExecuteNonQuery();
            }
            catch (Exception objExp)
            {
                mensaje = objExp.Message;
            }

            return mensaje;
        }

        public DataSet ejecutarConsulta(String consultaSql)//parametro  variable que recibe
        {
            DataSet objDs = new DataSet();
            try
            {
                ObjAdapter = new SqlDataAdapter(consultaSql, objConnection); //SqlDataAdapter llena el DataSet
                ObjAdapter.Fill(objDs);

            }
            catch (Exception objExp) // como este metodo ya no retorna mensaje
            {
                Mensaje = objExp.Message;
            }

            return objDs;
        }



    }
}
