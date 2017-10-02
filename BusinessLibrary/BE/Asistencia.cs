using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class Asistencia : Audit
    {

        private int mIdAsistencia = 0;
        private string mCodigo = "";
        private int mTurno = 0;
        private DateTime mFechaHoraEntrada = DateTime.Now;
        private DateTime mFechaHoraSalida = DateTime.Now;
        private string mOrigen = "";
        private DateTime mFechaRegistro = DateTime.Now;

        public int IdAsistencia
        {
            get
            {
                return mIdAsistencia;
            }

            set
            {
                mIdAsistencia = value;
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

        public DateTime FechaHoraEntrada
        {
            get
            {
                return mFechaHoraEntrada;
            }

            set
            {
                mFechaHoraEntrada = value;
            }
        }

        public DateTime FechaHoraSalida
        {
            get
            {
                return mFechaHoraSalida;
            }

            set
            {
                mFechaHoraSalida = value;
            }
        }

        public string Origen
        {
            get
            {
                return mOrigen;
            }

            set
            {
                mOrigen = value;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return mFechaRegistro;
            }

            set
            {
                mFechaRegistro = value;
            }
        }

        public int Turno
        {
            get
            {
                return mTurno;
            }

            set
            {
                mTurno = value;
            }
        }
    }

}
