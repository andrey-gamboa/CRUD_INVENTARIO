using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_INVENTARIO.Mantenimientos
{
    public class cls_Auditoria_DAL
    {
        #region Variables Privadas 
        //Sección de campos de la tabla

        private int _iId_Auditoria, _iId_Usuario;
        private string _sAccion, _sDescripción;
        private DateTime _dFechaDD, _dFechaHH;
        //Sección de campos de la tabla

        //Sección presente en todas las clases
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;


        //Sección presente en todas las clases
        #endregion

        #region Variables Públicas o Constructores
        public int iId_Auditoria { get => _iId_Auditoria; set => _iId_Auditoria = value; }
        public int iId_Usuario { get => _iId_Usuario; set => _iId_Usuario = value; }
        public string sAccion { get => _sAccion; set => _sAccion = value; }
        public string sDescripción { get => _sDescripción; set => _sDescripción = value; }
        public DateTime dFechaDD { get => _dFechaDD; set => _dFechaDD = value; }
        public DateTime dFechaHH { get => _dFechaHH; set => _dFechaHH = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}
