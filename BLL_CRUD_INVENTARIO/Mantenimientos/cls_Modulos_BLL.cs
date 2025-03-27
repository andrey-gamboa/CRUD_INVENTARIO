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
    public class cls_Modulos_BLL
    {
        public void listarFiltrarModulos(ref cls_Modulos_DAL obj_Modulos_DAL)
        {
            try
            {
                /**Se requieren en todos los metodos de bll*/
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                /**Se requieren en todos los metodos de bll*/

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Modulos"];
                Obj_BD_DAL.DT_Parametros = null;
                Obj_BD_DAL.sNomTabla = "Modulos";

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Modulos_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Modulos_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
