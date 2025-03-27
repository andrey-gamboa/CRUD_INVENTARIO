﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_CRUD_INVENTARIO.Mantenimientos;
using DAL_CRUD_INVENTARIO.Mantenimientos;

namespace PL_CRUD_INVENTARIO.Mantenimientos
{
    public partial class frmMantenimientoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Usuarios_DAL.iId_Usuario != 0)
                {
                    //Ejecutar en lógica de negocio el proceso o la accion necesaria
                    obj_Usuarios_BLL.Obtiene_Informacion_Usuarios(ref obj_Usuarios_DAL);

                    if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                            obj_Usuarios_DAL.dtDatos.Rows[0][6].ToString();
                    }
                    else
                    {
                        _mensaje = "No se encontraron registros";
                    }
                }
                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string MantenimientoUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[1].ToString();
                obj_Usuarios_DAL.sNombre = obj_Parametros_JS[2].ToString();
                obj_Usuarios_DAL.sPrim_Apellido = obj_Parametros_JS[3].ToString();
                obj_Usuarios_DAL.sSeg_Apellido = obj_Parametros_JS[4].ToString();
                obj_Usuarios_DAL.sPassword = obj_Parametros_JS[5].ToString();
                obj_Usuarios_DAL.sEstado = obj_Parametros_JS[6].ToString();
                obj_Usuarios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[7].ToString());

                if (obj_Usuarios_DAL.iId_Usuario == 0)
                {
                    obj_Usuarios_BLL.crearUsuarios(ref obj_Usuarios_DAL);
                }
                else
                {
                    obj_Usuarios_BLL.modificarUsuarios(ref obj_Usuarios_DAL);
                }

                if (obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Usuarios_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string EliminarUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Usuarios_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Usuarios_BLL.eliminarUsuarios(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencias asociados a la información que desea eliminar. Verifique!!!.";
                }
                else if (obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Usuarios_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}