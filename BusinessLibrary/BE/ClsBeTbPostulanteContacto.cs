using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulanteContacto : ICloneable
    {

        private int mIdPostulante = 0;
        private Ubigeo mUbigeo = null;
        private string mZona = "";
        private string mDireccion = "";
        private string mReferencia = "";
        private string mEmail = "";

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

        public ClsBeTbPostulanteContacto()
        {
        }
        
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
