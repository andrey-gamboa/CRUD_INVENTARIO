using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Usuarios_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iId_Usuario;
        private string _sCorreo, _sNombre, _sPrim_Apellido, _sSeg_Apellido, _sEstado, _sPassword;
        //Sección de campos de la tabla

        //Sección presente en todas las clases
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        //Sección presente en todas las clases
        #endregion

        #region Variables Públicas o Constructores
        public int iId_Usuario { get => _iId_Usuario; set => _iId_Usuario = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sNombre { get => _sNombre; set => _sNombre = value; }
        public string sPrim_Apellido { get => _sPrim_Apellido; set => _sPrim_Apellido = value; }
        public string sSeg_Apellido { get => _sSeg_Apellido; set => _sSeg_Apellido = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sPassword { get => _sPassword; set => _sPassword = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
