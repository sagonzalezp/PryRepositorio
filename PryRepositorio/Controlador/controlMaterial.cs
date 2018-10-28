using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using PryRepositorio.Modelo;

namespace PryRepositorio.Controlador
{
    public class controlMaterial
    {
        Material material;

        public controlMaterial(Material material)
        {
            this.material = material;
        }

        public String guardarMaterial()
        {
            String mensaje = "";
            try
            {
                Conexion conexion = new Conexion();
                String comandoSql;

                //guardar material
                comandoSql = String.Format(
                    "EXEC procInsertMaterial '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9}",
                    this.material.IdMaterial, this.material.Titulo, this.material.Descripcion, this.material.Requerimientos,
                    this.material.Tipo, this.material.Imagen,
                    this.material.Ruta, this.material.Propietario,
                    this.material.Movil, this.material.Costo);

                conexion.EjecutarCosulta(comandoSql);

                //guardar Metadatos
                guardarMetadatos();

                mensaje = "DATOS GUARDADOS CORRECTAMENTE";
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;
        }

        //CONSULTAR MATERIAL
        public DataSet Consultar()
        {
            String mensaje;
            DataSet objDs = new DataSet();
            Conexion conexion = new Conexion();
            try
            {
                SqlCommand cmd = new SqlCommand("procConsultarMaterial", conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 10);
                cmd.Parameters["@idMaterial"].Value = material.IdMaterial;
                conexion.Conex.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(objDs);

                conexion.Conex.Close();


            }
            catch (Exception objExc)
            {
                mensaje = objExc.Message;
            }

            return objDs;
        }


        //MODIFICAR MATERIAL
        public String modificarMaterial()
        {
            String mensaje = "";
            try
            {
                Conexion conexion = new Conexion();
                String comandoSql;

                comandoSql = String.Format(
                    "EXEC procModificarMaterial '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9}",
                    this.material.IdMaterial, this.material.Titulo, this.material.Descripcion, this.material.Requerimientos,
                    this.material.Tipo, this.material.Imagen,
                    this.material.Ruta, this.material.Propietario,
                    this.material.Movil, this.material.Costo);

                conexion.EjecutarCosulta(comandoSql);

                //volcar los metadatos de ese material
                comandoSql = String.Format("EXEC procVolcarMetadatos '{0}'", this.material.IdMaterial);
                conexion.EjecutarCosulta(comandoSql);

                //volverlos a guardar
                guardarMetadatos();

                mensaje = "DATOS ACTUALIZADOS CORRECTAMENTE";
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;

        }

        //ELIMINAR MATERIAL
        public String Eliminar()
        {
            Conexion conexion = new Conexion();
            DataSet DS;
            String comandoSql;
            String mensaje = "";
            String rutaMaterial;
            String rutaImagen;
            try
            {
                DS = this.Consultar();
                rutaMaterial = DS.Tables[0].Rows[0][8].ToString();
                rutaImagen = DS.Tables[0].Rows[0][7].ToString();

                SqlCommand cmd = new SqlCommand("procBorrarMaterial", conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 10);
                cmd.Parameters["@idMaterial"].Value = material.IdMaterial;
                conexion.Conex.Open();
                cmd.ExecuteNonQuery();
                conexion.Conex.Close();

                //volcar los metadatos de ese material
                comandoSql = String.Format("EXEC procVolcarMetadatos {0}", this.material.IdMaterial);
                conexion.EjecutarCosulta(comandoSql);

                File.Delete(rutaMaterial);
                File.Delete(rutaImagen);

                mensaje = "REGISTRO ELIMINADO";

            }
            catch (Exception objExc)
            {
                mensaje = objExc.Message;
            }
            return mensaje;
        }


        // GUARDAR METADATOS

        public String guardarMetadatos()
        {
            Conexion conexion = new Conexion();
            String mensaje = "";
            String comandoSql = "";

            try{
                for (int i = 0; i < material.Areas.Length; i++)
                {

                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Area1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Areas[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }

                //guardar Audiencias
                for (int i = 0; i < material.Audiencia.Length; i++)
                {
                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Audiencia1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Audiencia[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }

                //guardar autores
                for (int i = 0; i < material.Autores.Length; i++)
                {
                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Autor1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Autores[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }

                //guardar Formatos
                for (int i = 0; i < material.Formatos.Length; i++)
                {
                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Formato1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Formatos[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }

                //guardar keywords
                for (int i = 0; i < material.Keywords.Length; i++)
                {
                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Keyword1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Keywords[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }
                //guardar Lenguajes
                for (int i = 0; i < material.Lenguajes.Length; i++)
                {
                    comandoSql = String.Format(
                    "EXEC procInsertMaterial_Lenguaje1 '{0}','{1}'",
                    this.material.IdMaterial, this.material.Lenguajes[i].Nombre);

                    conexion.EjecutarCosulta(comandoSql);
                }
            }
            catch(Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;

            
        }


        //public String guardarMaterial()
        //{
        //    String mensaje = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("procInsertMaterial", objCon.Conex);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 10);
        //        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 30);
        //        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 30);
        //        //cmd.Parameters.Add("@fechaIngreso", SqlDbType.DateTime);
        //        cmd.Parameters.Add("@imagen", SqlDbType.VarChar, -1);
        //        cmd.Parameters.Add("@ruta", SqlDbType.VarChar,-1);
        //        cmd.Parameters.Add("@propietario", SqlDbType.VarChar, 20);
        //        cmd.Parameters.Add("@movil", SqlDbType.Bit, 1);
        //        cmd.Parameters.Add("@costo", SqlDbType.Money, 10);
        //        //cmd.Parameters.Add("@autor", SqlDbType.Int);
        //        //cmd.Parameters.Add("@area", SqlDbType.VarChar, 10);

        //        cmd.Parameters["@idMaterial"].Value = idMaterial;
        //        cmd.Parameters["@titulo"].Value = titulo;
        //        cmd.Parameters["@descripcion"].Value = descripcion;
        //        cmd.Parameters["@tipo"].Value = tipo;
        //        //cmd.Parameters["@fechaIngreso"].Value = fechaIngreso;
        //        cmd.Parameters["@imagen"].Value = imagen; 
        //        cmd.Parameters["@ruta"].Value = ruta;
        //        cmd.Parameters["@propietario"].Value = propietario;
        //        cmd.Parameters["@movil"].Value = movil;
        //        //cmd.Parameters["@autor"].Value = autor;
        //        //cmd.Parameters["@area"].Value = area;
        //        objCon.Conex.Open();
        //        cmd.ExecuteNonQuery();
        //        objCon.Conex.Close();
        //        mensaje = "RESGISTRO GUARDADO";


        //    }
        //    catch (Exception objExc)
        //    {
        //        mensaje = objExc.Message;
        //    }
        //    return mensaje;
        //}

        //public String modificarMaterial()
        //{
        //    Conexion conexion = new Conexion();
        //    String mensaje = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("modificarMaterial", conexion.Conex);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 10);
        //        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 30);
        //        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50);
        //        cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 30);
        //        cmd.Parameters.Add("@autor", SqlDbType.Int);
        //        cmd.Parameters.Add("@area", SqlDbType.VarChar, 10);
        //        cmd.Parameters.Add("@fechaModificacion", SqlDbType.DateTime);
        //        cmd.Parameters.Add("@imagen", SqlDbType.VarChar, -1);
        //        cmd.Parameters.Add("@ruta", SqlDbType.VarChar, -1);



        //        cmd.Parameters["@idMaterial"].Value = material.IdMaterial;
        //        cmd.Parameters["@titulo"].Value = material.Titulo;
        //        cmd.Parameters["@descripcion"].Value = material.Descripcion;
        //        cmd.Parameters["@tipo"].Value = material.Tipo;
        //        cmd.Parameters["@autor"].Value = material.Autores;
        //        cmd.Parameters["@area"].Value = material.Areas;
        //        cmd.Parameters["@fechaModificacion"].Value = material.FechaIngreso;
        //        cmd.Parameters["@imagen"].Value = material.Imagen;
        //        cmd.Parameters["@ruta"].Value = material.Ruta;


        //        conexion.Conex.Open();
        //        cmd.ExecuteNonQuery();
        //        conexion.Conex.Close();
        //        mensaje = "RESGISTRO MODIFICADO";


        //    }
        //    catch (Exception objExc)
        //    {
        //        mensaje = objExc.Message;
        //    }
        //    return mensaje;
        //}

    }
}