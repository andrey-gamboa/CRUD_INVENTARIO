using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Proveedores_DAL
    {

        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iIdProveedor;
        private string _sProveedor, _sContacto, _sDireccion, _sTelefono, _sCorreo, _sEstado;
        //Sección de campos de la tabla

        //Sección presente en todas las clases
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;

        //Sección presente en todas las clases

        public int iIdProveedor { get => _iIdProveedor; set => _iIdProveedor = value; }
        public string sProveedor { get => _sProveedor; set => _sProveedor = value; }
        public string sContacto { get => _sContacto; set => _sContacto = value; }
        public string sDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
