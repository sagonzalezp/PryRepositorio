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
    {//namespace estructura que almacena namespace o clases
        SqlConnection objcon;//declarando atributo
        SqlCommand objComm;
        SqlDataAdapter objAdapt;
        String cadenaConexion;
        String mensaje;

        public string Mensaje { get => mensaje; set => mensaje = value; }
        public SqlConnection Objcon { get => objcon; set => objcon = value; }

        public Conexion(String cadenaConexion)
        {
            objcon = null;
            objComm = null;
            objAdapt = null;
            this.cadenaConexion = cadenaConexion;
            mensaje = "";
           

        }

        public Conexion(String cadenaConexion,SqlConnection objcon)
        {
            this.objcon = objcon;
            objComm = null;
            objAdapt = null;
            this.cadenaConexion = cadenaConexion;
        }

        public Conexion()
        {
            this.objcon = null;
            objComm = null;
            objAdapt = null;
            this.cadenaConexion =null;
        }

        public String abrirConexion()
        {
            
            try
            {
                objcon = new SqlConnection(cadenaConexion);//declarando clase
                objcon.Open();

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
                objcon.Close();

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
               
                objComm = new SqlCommand(comandoSql, objcon);//argumento dato que se envia
                objComm.ExecuteNonQuery();
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
                objAdapt = new SqlDataAdapter(consultaSql, objcon); //SqlDataAdapter llena el DataSet
                objAdapt.Fill(objDs);

            }
            catch (Exception objExp) // como este metodo ya no retorna mensaje
            {
                Mensaje = objExp.Message;
            }

            return objDs;
        }



    }
}
