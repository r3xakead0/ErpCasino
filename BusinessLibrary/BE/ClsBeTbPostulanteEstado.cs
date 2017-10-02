using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulanteEstado : ICloneable
    {

        private int mIdPostulanteEstado = 0;
        private int mNivel = 0;
        private string mNombre = "";
        private string mDescripcion = "";
        private int mDependencia = 0;
        private bool mActivo = false;

        public int IdPostulanteEstado
        {
            get
            {
                return mIdPostulanteEstado;
            }

            set
            {
                mIdPostulanteEstado = value;
            }
        }

        public int Nivel
        {
            get
            {
                return mNivel;
            }

            set
            {
                mNivel = value;
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

        public int Dependencia
        {
            get
            {
                return mDependencia;
            }

            set
            {
                mDependencia = value;
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

        public ClsBeTbPostulanteEstado()
        {
           
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
