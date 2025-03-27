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
    public class cls_ModulosXUsuario_BLL
    {
        public void listarFiltrarModulosXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /**Se requieren en todos los metodos de bll*/
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                /**Se requieren en todos los metodos de bll*/

                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //orden de parametros: nombre, tipo de dato, valor del parametro
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_ModulosXUsuario_DAL.iIdUsuario);

                //Indicar a la base de datos (Nombre del STPR, Nombre Logico DataTable, Parametros, Metodo a Ejecutar)
                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_ModulosXUsuario"];
                Obj_BD_DAL.sNomTabla = "ModulosXUsuario";
                Obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;

                Obj_BD_BLL.EjecutaProcesosTabla(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.dtDatos = Obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_ModulosXUsuario_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void asignarModulosXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /**Se requieren en todos los metodos de bll*/
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                /**Se requieren en todos los metodos de bll*/

                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //orden de parametros: nombre, tipo de dato, valor del parametro

                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdModulo", "1", obj_ModulosXUsuario_DAL.iIdModulo);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_ModulosXUsuario_DAL.iIdUsuario);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ModulosXUsuario_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_ModulosXUsuario"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;

                Obj_BD_BLL.EjecutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ModulosXUsuario_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarModulosXUsuario(ref cls_ModulosXUsuario_DAL obj_ModulosXUsuario_DAL)
        {
            try
            {
                /**Se requieren en todos los metodos de bll*/
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                /**Se requieren en todos los metodos de bll*/

                obj_ModulosXUsuario_DAL.dtParametros = null;
                obj_ModulosXUsuario_DAL.dtParametros = Obj_BD_BLL.ObtieneDTParametros(obj_ModulosXUsuario_DAL.dtParametros);

                //orden de parametros: nombre, tipo de dato, valor del parametro
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdModuloUsuario", "1", obj_ModulosXUsuario_DAL.iIdModuloUsuario);
                obj_ModulosXUsuario_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_ModulosXUsuario_DAL.iIdUsuarioGlobal);

                Obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Elim_ModulosXUsuario"];
                Obj_BD_DAL.sIndAxn = "SCALAR";
                Obj_BD_DAL.DT_Parametros = obj_ModulosXUsuario_DAL.dtParametros;

                Obj_BD_BLL.EjecutaProcesosComando(ref Obj_BD_DAL);

                if (Obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_ModulosXUsuario_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = Obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_ModulosXUsuario_DAL.sMSJError = Obj_BD_DAL.sMsjErrorBD;
                    obj_ModulosXUsuario_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
