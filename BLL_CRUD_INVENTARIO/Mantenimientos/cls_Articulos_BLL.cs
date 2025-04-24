using BLL_CRUD_INVENTARIO.BD;
using DAL_CRUD_INVENTARIO.BD;
using DAL_CRUD_INVENTARIO.Mantenimientos;
using System;
using System.Configuration;

namespace BLL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Articulos_BLL
    {
        public void listarFiltrarArticulos(ref cls_Articulos_DAL obj_Articulos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                //Listar Datos
                if (
                    ((obj_Articulos_DAL.sDescripcion == string.Empty) || (obj_Articulos_DAL.sDescripcion == null))
                    &&
                     ((obj_Articulos_DAL.iIdProveedor == 0))
                     )
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Articulos"];
                    obj_BD_DAL.DT_Parametros = null;
                    obj_BD_DAL.sNomTabla = "Articulos";
                }
                else //Filtrar Datos
                {
                    /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                    obj_Articulos_DAL.dtParametros = null;
                    obj_Articulos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Articulos_DAL.dtParametros);

                    //agregar los parámetros que requiere el procedimiento almacenado
                    //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                    obj_Articulos_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Articulos_DAL.sDescripcion);
                    obj_Articulos_DAL.dtParametros.Rows.Add("@Proveedor", "1", obj_Articulos_DAL.iIdProveedor);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILL_Articulos"];
                    //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Articulos_DAL.dtParametros;
                    //Definimos un nombre de tabla lógico 
                    obj_BD_DAL.sNomTabla = "Articulos";
                }

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Articulos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Articulos_DAL.dtDatos = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }// checked

        public void Obtiene_Informacion_Articulo(ref cls_Articulos_DAL obj_Articulos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Articulos_DAL.dtParametros = null;
                obj_Articulos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Articulos_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Articulos_DAL.dtParametros.Rows.Add("@Id_Articulo", "1", obj_Articulos_DAL.iIdArticulo);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Articulos"];
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Articulos_DAL.dtParametros;
                //Definimos un nombre de tabla lógico 
                obj_BD_DAL.sNomTabla = "Articulos";

                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Articulos_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Articulos_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // checked

        public void crearArticulos(ref cls_Articulos_DAL obj_Articulos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Articulos_DAL.dtParametros = null;
                obj_Articulos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Articulos_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Articulos_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Articulos_DAL.sDescripcion);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Articulos_DAL.sEstado);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Existencias", "1", obj_Articulos_DAL.iExistencias);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Precio", "2", obj_Articulos_DAL.dPrecio);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Id_Proveedor", "1", obj_Articulos_DAL.iIdProveedor);
                obj_Articulos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Articulos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Articulos"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Articulos_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }  // checked

        public void modificarArticulos(ref cls_Articulos_DAL obj_Articulos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Articulos_DAL.dtParametros = null;
                obj_Articulos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Articulos_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Articulos_DAL.dtParametros.Rows.Add("@Id_Articulo ", "1", obj_Articulos_DAL.iIdArticulo);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Descripcion", "6", obj_Articulos_DAL.sDescripcion);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Articulos_DAL.sEstado);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Existencias", "1", obj_Articulos_DAL.iExistencias);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Precio", "2", obj_Articulos_DAL.dPrecio);
                obj_Articulos_DAL.dtParametros.Rows.Add("@Id_Proveedor", "1", obj_Articulos_DAL.iIdProveedor);
                obj_Articulos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Articulos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Articulos"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Articulos_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } // checked

        public void eliminarArticulos(ref cls_Articulos_DAL obj_Articulos_DAL)
        {
            try
            {
                /* Objetos para comunicación al ámbito de BD */
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto de acceso a datos de BD
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto de lógica de negocio de BD

                /*Dar forma al atributo de Data Table de Parametros del Objeto en cuestión*/
                obj_Articulos_DAL.dtParametros = null;
                obj_Articulos_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Articulos_DAL.dtParametros);

                //agregar los parámetros que requiere el procedimiento almacenado
                //Regla: Orden de Valores del Parámetro: Nombre, Código de Tipo de Dato, Valor
                obj_Articulos_DAL.dtParametros.Rows.Add("@Id_Articulo", "1", obj_Articulos_DAL.iIdProveedor);
                obj_Articulos_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Articulos_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Elim_Articulos"];
                //Determinar el tipo de axión a ejecutar
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Le asignamos al DT Parametros de BD_DAL la lista de parametros construida en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Articulos_DAL.dtParametros;

                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de BD es vacío... todo salió de forma correcta, recuperemos lo valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Articulos_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Articulos_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } // checked
    }
}

