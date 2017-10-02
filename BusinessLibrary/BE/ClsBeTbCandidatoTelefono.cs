using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbCandidatoTelefono 
    {

        private int mIdCandidatoTelefono = 0;
        private int mIdCandidato = 0;
        private string mCodTipoTelefono = "";
        private string mNumero = "";

        public int IdCandidatoTelefono
        {
            get
            {
                return mIdCandidatoTelefono;
            }
            set
            {
                mIdCandidatoTelefono = value;
            }
        }

        public int IdCandidato
        {
            get
            {
                return mIdCandidato;
            }
            set
            {
                mIdCandidato = value;
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

        public ClsBeTbCandidatoTelefono()
        {
        }

    }

}
