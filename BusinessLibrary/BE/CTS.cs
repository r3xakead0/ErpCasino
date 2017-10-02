using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class CTS
    {

        private int mIdCts = 0;
        private string mCodigoEmpleado = "";
        private double mMonto = 0.0;
        private DateTime mFechaPeriodoInicial = DateTime.Now;
        private DateTime mFechaPeriodoFinal = DateTime.Now;
        private DateTime mFechaDeposito = DateTime.Now;

        public int IdCts
        {
            get
            {
                return mIdCts;
            }
            set
            {
                mIdCts = value;
            }
        }

        public string CodigoEmpleado
        {
            get
            {
                return mCodigoEmpleado;
            }
            set
            {
                mCodigoEmpleado = value;
            }
        }

        public double Monto
        {
            get
            {
                return mMonto;
            }
            set
            {
                mMonto = value;
            }
        }

        public DateTime FechaPeriodoInicial
        {
            get
            {
                return mFechaPeriodoInicial;
            }
            set
            {
                mFechaPeriodoInicial = value;
            }
        }

        public DateTime FechaPeriodoFinal
        {
            get
            {
                return mFechaPeriodoFinal;
            }
            set
            {
                mFechaPeriodoFinal = value;
            }
        }

        public DateTime FechaDeposito
        {
            get
            {
                return mFechaDeposito;
            }
            set
            {
                mFechaDeposito = value;
            }
        }

        public CTS()
        {
        }
        

    }
}
