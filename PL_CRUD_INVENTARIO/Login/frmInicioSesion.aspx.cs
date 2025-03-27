using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_CRUD_INVENTARIO.Mantenimientos;
using BLL_CRUD_INVENTARIO.Mantenimientos;
using System.Web.Services;

namespace PL_CRUD_INVENTARIO.Login
{
    public partial class frmInicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        [WebMethod]
        public static string InicioSesionUsuarios(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
                cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Usuarios_DAL.sCorreo = obj_Parametros_JS[0].ToString();
                obj_Usuarios_DAL.sPassword = obj_Parametros_JS[1].ToString();

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Usuarios_BLL.Inicio_Sesion_Usuarios(ref obj_Usuarios_DAL);

                //Recuperamos y evaluamos los valores scalares y / o de respuesta de BD
                if (obj_Usuarios_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El usuario se encuentra inactivo, por favor contacte al administrador del sistema";
                }
                else if (obj_Usuarios_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "El usuario y / o contraseña no son válidos. Verifique!!!";
                }
                else
                {
                    obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);

                    obj_Usuarios_BLL.Obtiene_Informacion_Usuarios(ref obj_Usuarios_DAL);

                    _mensaje = obj_Usuarios_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                        "Bienvenido de nuevo: " + obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                                                  obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                                                  obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                        obj_Usuarios_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                        obj_Usuarios_DAL.dtDatos.Rows[0][1].ToString() + " " +
                        obj_Usuarios_DAL.dtDatos.Rows[0][2].ToString() + " " +
                        obj_Usuarios_DAL.dtDatos.Rows[0][3].ToString();

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