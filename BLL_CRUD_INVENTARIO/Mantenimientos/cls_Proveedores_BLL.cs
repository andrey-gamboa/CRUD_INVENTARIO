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
    public class cls_Proveedores_BLL
    {
        public void listarFiltrarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                //Listar Datos
                if (
                    ((obj_Proveedores_DAL.sProveedor == string.Empty) || (obj_Proveedores_DAL.sProveedor == null))
                    &&
                     ((obj_Proveedores_DAL.sContacto == string.Empty) || (obj_Proveedores_DAL.sContacto == null))
                    &&
                    ((obj_Proveedores_DAL.sEstado == string.Empty) || (obj_Proveedores_DAL.sEstado == null))
                    )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Proveedores"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Proveedores";
                }
                else //Filtrar Datos
                {
                    /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                    obj_Proveedores_DAL.dtParametros = null;
                    obj_Proveedores_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Proveedores_DAL.dtParametros);

                    //agregar los parámetros que requiere el procedimiento almacenado
                    //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                    obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                    obj_Proveedores_DAL.dtParametros.Rows.Add("@Contacto", "6", obj_Proveedores_DAL.sContacto);
                    obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Proveedores"];
                    //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;
                    //Definimos un nombre de tabla lógico 
                    obj_BD_DAL.sNomTabla = "Proveedores";
                }

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Proveedores_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }// checked

        public void Obtiene_Informacion_Proveedor(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Proveedores_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Proveedores"];
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;
                //Definimos un nombre de tabla lógico 
                obj_BD_DAL.sNomTabla = "Proveedores";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Proveedores_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // checked

        public void crearProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Proveedores_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Contacto", "6", obj_Proveedores_DAL.sContacto);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Proveedores_DAL.sTelefono);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Proveedores_DAL.sCorreo);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Proveedores_DAL.sDireccion);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Proveedores"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }  // checked

        public void modificarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Proveedores_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Proveedor", "6", obj_Proveedores_DAL.sProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Contacto", "6", obj_Proveedores_DAL.sContacto);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Proveedores_DAL.sTelefono);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Proveedores_DAL.sCorreo);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Proveedores_DAL.sDireccion);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Proveedores_DAL.sEstado);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Proveedores"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } // checked

        public void eliminarProveedores(ref cls_Proveedores_DAL obj_Proveedores_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Proveedores_DAL.dtParametros = null;
                obj_Proveedores_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Proveedores_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdProveedor", "1", obj_Proveedores_DAL.iIdProveedor);
                obj_Proveedores_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Proveedores_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Elim_Proveedores"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Proveedores_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Proveedores_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Proveedores_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } // checked
    }
}
