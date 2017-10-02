using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Banco 
    {

        private int mIdBanco = 0;
        private string mCodigo = null;
        private string mNombre = null;
        private string mDescripcion = null;
        private bool mActivo = false;

        public int IdBanco
        {
            get
            {
                return mIdBanco;
            }
            set
            {
                mIdBanco = value;
            }
        }

        public string Codigo
        {
            get
            {
                return mCodigo;
            }
            set
            {
                mCodigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return mNombre;
            }
            set
            {
                mNombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return mDescripcion;
            }
            set
            {
                mDescripcion = value;
            }
        }

        public bool Activo
        {
            get
            {
                return mActivo;
            }
            set
            {
                mActivo = value;
            }
        }

        public Banco()
        {
        }


    }

}
