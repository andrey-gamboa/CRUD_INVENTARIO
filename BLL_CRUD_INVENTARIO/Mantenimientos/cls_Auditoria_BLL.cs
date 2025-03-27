using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_CRUD_INVENTARIO.BD;
using DAL_CRUD_INVENTARIO.BD;
using DAL_CRUD_INVENTARIO.Mantenimientos;

namespace BLL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Auditoria_BLL
    {

        public void listarFiltrarAuditoria(ref cls_Auditoria_DAL obj_Auditoria_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                //Filtrar Datos
                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Auditoria_DAL.dtParametros = null;
                obj_Auditoria_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Auditoria_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Usuario", "1", obj_Auditoria_DAL.iId_Usuario);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Accion", "6", obj_Auditoria_DAL.sAccion);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Desde", "8", obj_Auditoria_DAL.dFechaDD);
                obj_Auditoria_DAL.dtParametros.Rows.Add("@Hasta", "8", obj_Auditoria_DAL.dFechaHH);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Auditoria"];
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Auditoria_DAL.dtParametros;
                //Definimos un nombre de tabla lógico 
                obj_BD_DAL.sNomTabla = "Auditoria";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Auditoria_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Auditoria_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
