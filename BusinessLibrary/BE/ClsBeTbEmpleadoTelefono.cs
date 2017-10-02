using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbEmpleadoTelefono 
    {

        private int mIdEmpleadoTelefono = 0;
        private int mIdEmpleado = 0;
        private string mCodTipoTelefono = "";
        private string mNumero = "";

        public int IdEmpleadoTelefono
        {
            get
            {
                return mIdEmpleadoTelefono;
            }
            set
            {
                mIdEmpleadoTelefono = value;
            }
        }

        public int IdEmpleado
        {
            get
            {
                return mIdEmpleado;
            }
            set
            {
                mIdEmpleado = value;
            }
        }

        public string CodTipoTelefono
        {
            get
            {
                return mCodTipoTelefono;
            }
            set
            {
                mCodTipoTelefono = value;
            }
        }

        public string Numero
        {
            get
            {
                return mNumero;
            }
            set
            {
                mNumero = value;
            }
        }

        public ClsBeTbEmpleadoTelefono()
        {
        }
        

    }

}
