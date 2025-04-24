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
    public partial class frmConsultaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string CargaListaArticulos(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Articulos_DAL obj_Articulos_DAL = new cls_Articulos_DAL();
                cls_Articulos_BLL obj_Articulos_BLL = new cls_Articulos_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Articulos_DAL.sDescripcion = obj_Parametros_JS[0].ToString();
                obj_Articulos_DAL.iIdProveedor = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Articulos_BLL.listarFiltrarArticulos(ref obj_Articulos_DAL);


                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Articulos_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Id Articulo</th>" +
                        "<th>Descripcion</th>" +
                         "<th>Estado</th>" +
                        "<th>Existencias</th>" +
                        "<th>Precio</th>" +
                        "<th>Proveedor</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Articulos_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript:defineArticulo(" + obj_Articulos_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                                        obj_Articulos_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Articulos_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Articulos_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                                    "<td>" + obj_Articulos_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                                    "<td>" + obj_Articulos_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                                    "<td>" + obj_Articulos_DAL.dtDatos.Rows[i][5].ToString() + "</td>" +
                                    "<td style='text-align:center'><i class='fa fa-trash-o' onclick='javascript:eliminaArticulo(" + obj_Articulos_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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
    }
}
    
