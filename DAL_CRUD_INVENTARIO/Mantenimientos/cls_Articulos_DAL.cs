using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Articulos_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iIdArticulo, _iExistencias, _iIdProveedor;
        private decimal _dPrecio;
        private string _sDescripcion, _sEstado;

        //Sección presente en todas las clases
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;

        public int iIdArticulo { get => _iIdArticulo; set => _iIdArticulo = value; }
        public int iExistencias { get => _iExistencias; set => _iExistencias = value; }
        public int iIdProveedor { get => _iIdProveedor; set => _iIdProveedor = value; }
        public decimal dPrecio { get => _dPrecio; set => _dPrecio = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
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
