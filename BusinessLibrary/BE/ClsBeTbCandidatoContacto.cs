using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbCandidatoContacto : ICloneable
    {

        private int mIdCandidato = 0;
        private Ubigeo mUbigeo = null;
        private string mZona = "";
        private string mDireccion = "";
        private string mReferencia = "";
        private string mEmail = "";

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

        public string Direccion
        {
            get
            {
                return mDireccion;
            }
            set
            {
                mDireccion = value;
            }
        }

        public string Referencia
        {
            get
            {
                return mReferencia;
            }
            set
            {
                mReferencia = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }

        public Ubigeo Ubigeo
        {
            get
            {
                return mUbigeo;
            }

            set
            {
                mUbigeo = value;
            }
        }

        public string Zona
        {
            get
            {
                return mZona;
            }

            set
            {
                mZona = value;
            }
        }

        public ClsBeTbCandidatoContacto()
        {
        }
        
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
