using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_ModulosXUsuario_DAL
    {
        #region Variables Privadas
        private int _iIdModuloUsuario, _iIdUsuario, _iIdModulo;
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion


        #region Variables Públicas o Constructores
        public int iIdModuloUsuario { get => _iIdModuloUsuario; set => _iIdModuloUsuario = value; }
        public int iIdUsuario { get => _iIdUsuario; set => _iIdUsuario = value; }
        public int iIdModulo { get => _iIdModulo; set => _iIdModulo = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
