using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_CRUD_INVENTARIO.Mantenimientos;
using BLL_CRUD_INVENTARIO.Mantenimientos;

namespace PL_CRUD_INVENTARIO.Mantenimientos
{
    public partial class frmMantenimientoModulosXUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaModulos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Modulos_DAL obj_Modulos_DAL = new cls_Modulos_DAL();
                cls_Modulos_BLL obj_Modulos_BLL = new cls_Modulos_BLL();

                obj_Modulos_BLL.listarFiltrarModulos(ref obj_Modulos_DAL);

                if (obj_Modulos_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Módulo</th>" +
                                "<th style='text-align:center'>Asignar</th>" +
                                "</tr>" +
                                "<tbody>";

                    for (int i = 0; i < obj_Modulos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_Modulos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-book' onclick='javascript:asignaModulosXUsuario(" + obj_Modulos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
                                    "</tr>";
                    }
                    _mensaje += "</tbody>";
                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [WebMethod]
        public static string CargaListaModulosXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                obj_ModulosXUsuario_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                obj_ModulosXUsuario_BLL.listarFiltrarModulosXUsuario(ref obj_ModulosXUsuario_DAL);

                if (obj_ModulosXUsuario_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                                "<thead>" +
                                "<tr>" +
                                "<th>Módulo</th>" +
                                "<th style='text-align:center'>Eliminar</th>" +
                                "</tr>" +
                                "<tbody>";

                    for (int i = 0; i < obj_ModulosXUsuario_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_ModulosXUsuario_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaModuloXUsuario(" + obj_ModulosXUsuario_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer;'></i></td>" +
                                    "</tr>";
                    }
                    _mensaje += "</tbody>";
                }
                else
                {
                    _mensaje = "No se encontraron registros";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [WebMethod]
        public static string AsignarModulosXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                obj_ModulosXUsuario_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros_JS[0]);
                obj_ModulosXUsuario_DAL.iIdModulo = Convert.ToInt32(obj_Parametros_JS[1]);
                obj_ModulosXUsuario_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2]);

                obj_ModulosXUsuario_BLL.asignarModulosXUsuario(ref obj_ModulosXUsuario_DAL);


                if (obj_ModulosXUsuario_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "El módulo ya ha sido asignado al Usuario";
                }
                else if (obj_ModulosXUsuario_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente nuevamente";
                }
                else
                {
                    _mensaje = obj_ModulosXUsuario_DAL.sValorScalar + "<SPLITER>" + "Registro asignado de forma satisfactoria";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [WebMethod]
        public static string EliminarModulosXUsuario(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL = new cls_ModulosXUsuario_DAL();
                cls_ModulosXUsuario_BLL obj_ModulosXUsuario_BLL = new cls_ModulosXUsuario_BLL();

                obj_ModulosXUsuario_DAL.iIdUsuario = Convert.ToInt32(obj_Parametros_JS[0]);
                obj_ModulosXUsuario_DAL.iIdModuloUsuario = Convert.ToInt32(obj_Parametros_JS[1]);
                obj_ModulosXUsuario_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[2]);

                obj_ModulosXUsuario_BLL.eliminarModulosXUsuario(ref obj_ModulosXUsuario_DAL);


                if (obj_ModulosXUsuario_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No es posible completar la acción";
                }
                else if (obj_ModulosXUsuario_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente nuevamente";
                }
                else
                {
                    _mensaje = obj_ModulosXUsuario_DAL.sValorScalar + "<SPLITER>" + "Registro eliminado de forma satisfactoria";
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