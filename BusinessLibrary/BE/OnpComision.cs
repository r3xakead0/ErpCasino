using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class OnpComision
    {

        private int mIdOnpComision = 0;
        private int mAnho = 0;
        private int mMes = 0;
        private double mPorcentajeAporte = 0.0;

        public int IdOnpComision
        {
            get
            {
                return mIdOnpComision;
            }
            set
            {
                mIdOnpComision = value;
            }
        }

        public int Anho
        {
            get
            {
                return mAnho;
            }
            set
            {
                mAnho = value;
            }
        }

        public int Mes
        {
            get
            {
                return mMes;
            }
            set
            {
                mMes = value;
            }
        }

        public double PorcentajeAporte
        {
            get
            {
                return mPorcentajeAporte;
            }
            set
            {
                mPorcentajeAporte = value;
            }
        }

    }
}