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
    public partial class frmConsultaAuditoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaAuditoria(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Auditoria_DAL obj_Auditoria_DAL = new cls_Auditoria_DAL();
                cls_Auditoria_BLL obj_Auditoria_BLL = new cls_Auditoria_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto 
                obj_Auditoria_DAL.iId_Usuario = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Auditoria_DAL.sAccion = obj_Parametros_JS[1].ToString();
                obj_Auditoria_DAL.dFechaDD = Convert.ToDateTime(obj_Parametros_JS[2].ToString());
                obj_Auditoria_DAL.dFechaHH = Convert.ToDateTime(obj_Parametros_JS[3].ToString());

                //Ejecutar en lógica de negocio el proceso o la accion necesaria
                obj_Auditoria_BLL.listarFiltrarAuditoria(ref obj_Auditoria_DAL);


                //Evaluar los resultados de la ejecución de la lógica de negocio
                if (obj_Auditoria_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Fecha / Hora</th>" +
                        "<th>Acción</th>" +
                        "<th>Descripción</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Auditoria_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                                    "<td>" + obj_Auditoria_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
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