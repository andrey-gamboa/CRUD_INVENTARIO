using System;
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
    public partial class frmMantenimientoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CargaInfoArticulo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Articulos_DAL obj_Articulos_DAL = new cls_Articulos_DAL();
                cls_Articulos_BLL obj_Articulos_BLL = new cls_Articulos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Articulos_DAL.iIdArticulo = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Articulos_DAL.iIdArticulo != 0)
                {
                    //Ejecutar en lógica de negocio el proceso o la accion necesaria
                    obj_Articulos_BLL.Obtiene_Informacion_Articulo(ref obj_Articulos_DAL);

                    if (obj_Articulos_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Articulos_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                            obj_Articulos_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                            obj_Articulos_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                            obj_Articulos_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                            obj_Articulos_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                            obj_Articulos_DAL.dtDatos.Rows[0][5].ToString();
                             
                           
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
        public static string MantenimientoArticulos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Articulos_DAL obj_Articulos_DAL = new cls_Articulos_DAL();
                cls_Articulos_BLL obj_Articulos_BLL = new cls_Articulos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Articulos_DAL.iIdArticulo = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Articulos_DAL.sDescripcion = obj_Parametros_JS[1].ToString();
                obj_Articulos_DAL.sEstado = obj_Parametros_JS[2].ToString();
                obj_Articulos_DAL.iExistencias = Convert.ToInt32(obj_Parametros_JS[3].ToString());
                obj_Articulos_DAL.dPrecio = Convert.ToDecimal(obj_Parametros_JS[4].ToString());
                obj_Articulos_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[5].ToString());
                obj_Articulos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[6].ToString());

                if (obj_Articulos_DAL.iIdArticulo == 0)
                {
                    obj_Articulos_BLL.crearArticulos(ref obj_Articulos_DAL);
                }
                else
                {
                    obj_Articulos_BLL.modificarArticulos(ref obj_Articulos_DAL);
                }

                if (obj_Articulos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Articulos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Articulos_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string EliminarArticulos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Articulos_DAL obj_Articulos_DAL = new cls_Articulos_DAL();
                cls_Articulos_BLL obj_Articulos_BLL = new cls_Articulos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Articulos_DAL.iIdArticulo = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Articulos_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                obj_Articulos_BLL.eliminarArticulos(ref obj_Articulos_DAL);

                if (obj_Articulos_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencias asociados a la información que desea eliminar. Verifique!!!.";
                }
                else if (obj_Articulos_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente nuevamente.";
                }
                else
                {
                    _mensaje = obj_Articulos_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
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