using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulanteHistorial : ICloneable
    {
        private int mIdPostulante = 0;
        private ClsBeTbPostulanteEstado mEstado = null;
        private bool mAcepto = false;
        private string mNota = "";

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
        

        public string Nota
        {
            get
            {
                return mNota;
            }

            set
            {
                mNota = value;
            }
        }

        public ClsBeTbPostulanteEstado Estado
        {
            get
            {
                return mEstado;
            }

            set
            {
                mEstado = value;
            }
        }

        public bool Acepto
        {
            get
            {
                return mAcepto;
            }

            set
            {
                mAcepto = value;
            }
        }

        public ClsBeTbPostulanteHistorial()
        {
            Estado = new ClsBeTbPostulanteEstado();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
