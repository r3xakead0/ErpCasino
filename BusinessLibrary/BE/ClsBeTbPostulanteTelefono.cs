using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulanteTelefono 
    {

        private int mIdPostulanteTelefono = 0;
        private int mIdPostulante = 0;
        private string mCodTipoTelefono = "";
        private string mNumero = "";

        public int IdPostulanteTelefono
        {
            get
            {
                return mIdPostulanteTelefono;
            }
            set
            {
                mIdPostulanteTelefono = value;
            }
        }

        public int IdPostulante
        {
            get
            {
                return mIdPostulante;
            }
            set
            {
                mIdPostulante = value;
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

        public ClsBeTbPostulanteTelefono()
        {
        }


    }

}
