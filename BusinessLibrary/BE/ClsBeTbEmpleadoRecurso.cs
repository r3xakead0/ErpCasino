using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbEmpleadoRecurso : ICloneable
    {

        private int mIdEmpleado = 0;
        private Area mArea = null;
        private Cargo mCargo = null;
        private Sala mSala = null;
        private DateTime mFechaInicio = DateTime.Now;
        private DateTime? mFechaCese = null;
        private bool mCesado = false;
        private int mNumeroHijos = 0;
        private Banco mBanco = null;
        private string mCuentaBanco = "";
        private Banco mBancoCTS = null;
        private string mCuentaCTS = "";
        private string mCCI = "";
        private bool mONP = false;
        private Afp mAfp = null;
        private string mCUSPP = "";
        private string mCodComision = "";
        private double mSueldo = 0.0;
        private double mRetencionJudicialNominal = 0.0;
        private double mRetencionJudicialPorcentual = 0.0;

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

        public Area Area
        {
            get
            {
                return mArea;
            }
            set
            {
                mArea = value;
            }
        }

        public Cargo Cargo
        {
            get
            {
                return mCargo;
            }
            set
            {
                mCargo = value;
            }
        }

        public DateTime FechaInicio
        {
            get
            {
                return mFechaInicio;
            }
            set
            {
                mFechaInicio = value;
            }
        }

        public DateTime? FechaCese
        {
            get
            {
                return mFechaCese;
            }
            set
            {
                mFechaCese = value;
            }
        }

        public bool Cesado
        {
            get
            {
                return mCesado;
            }
            set
            {
                mCesado = value;
            }
        }

        public int NumeroHijos
        {
            get
            {
                return mNumeroHijos;
            }
            set
            {
                mNumeroHijos = value;
            }
        }

        public Banco Banco
        {
            get
            {
                return mBanco;
            }
            set
            {
                mBanco = value;
            }
        }

        public string CuentaBanco
        {
            get
            {
                return mCuentaBanco;
            }
            set
            {
                mCuentaBanco = value;
            }
        }

        public string CuentaCTS
        {
            get
            {
                return mCuentaCTS;
            }
            set
            {
                mCuentaCTS = value;
            }
        }

        public string CCI
        {
            get
            {
                return mCCI;
            }
            set
            {
                mCCI = value;
            }
        }

        public bool ONP
        {
            get
            {
                return mONP;
            }
            set
            {
                mONP = value;
            }
        }

        public Afp Afp
        {
            get
            {
                return mAfp;
            }
            set
            {
                mAfp = value;
            }
        }

        public string CUSPP
        {
            get
            {
                return mCUSPP;
            }
            set
            {
                mCUSPP = value;
            }
        }

        public string CodComision
        {
            get
            {
                return mCodComision;
            }
            set
            {
                mCodComision = value;
            }
        }

        public double Sueldo
        {
            get
            {
                return mSueldo;
            }

            set
            {
                mSueldo = value;
            }
        }

        public Banco BancoCTS
        {
            get
            {
                return mBancoCTS;
            }

            set
            {
                mBancoCTS = value;
            }
        }

        public Sala Sala
        {
            get
            {
                return mSala;
            }

            set
            {
                mSala = value;
            }
        }

        public double RetencionJudicialNominal
        {
            get
            {
                return mRetencionJudicialNominal;
            }

            set
            {
                mRetencionJudicialNominal = value;
            }
        }

        public double RetencionJudicialPorcentual
        {
            get
            {
                return mRetencionJudicialPorcentual;
            }

            set
            {
                mRetencionJudicialPorcentual = value;
            }
        }

        public ClsBeTbEmpleadoRecurso()
        {

        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
