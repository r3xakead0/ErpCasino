using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Gratificacion
    {

        private int mIdGratificacion = 0;
        private string mPeriodo = "";
        private DateTime mFechaInicio = DateTime.Now;
        private DateTime mFechaFinal = DateTime.Now;
        private int mDias = 0;
        private string mCodigoEmpleado = "";
        private double mBonoNocturnoPromedio = 0.0;
        private double mBonoHorasExtrasPromedio = 0.0;
        private double mSueldoBase = 0.0;
        private double mAsignacionFamiliar = 0.0;
        private int mDiasLaborados = 0;
        private double mGratificacionBruta = 0.0;
        private double mBonoExtraordinario = 0.0;
        private double mGratificacionNeta = 0.0;
        private double mDescuentoRetencionJudicial = 0.0;
        private double mDescuentoImpuesto = 0.0;
        private double mGratificacionPagar = 0.0;

        public List<GratificacionDetalle> Detalle { get; set; }

        public int IdGratificacion
        {
            get
            {
                return mIdGratificacion;
            }
            set
            {
                mIdGratificacion = value;
            }
        }

        public string Periodo
        {
            get
            {
                return mPeriodo;
            }
            set
            {
                mPeriodo = value;
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

        public DateTime FechaFinal
        {
            get
            {
                return mFechaFinal;
            }
            set
            {
                mFechaFinal = value;
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

        public double BonoNocturnoPromedio
        {
            get
            {
                return mBonoNocturnoPromedio;
            }
            set
            {
                mBonoNocturnoPromedio = value;
            }
        }

        public double BonoHorasExtrasPromedio
        {
            get
            {
                return mBonoHorasExtrasPromedio;
            }
            set
            {
                mBonoHorasExtrasPromedio = value;
            }
        }

        public double SueldoBase
        {
            get
            {
                return mSueldoBase;
            }
            set
            {
                mSueldoBase = value;
            }
        }

        public double AsignacionFamiliar
        {
            get
            {
                return mAsignacionFamiliar;
            }
            set
            {
                mAsignacionFamiliar = value;
            }
        }

        public int DiasLaborados
        {
            get
            {
                return mDiasLaborados;
            }
            set
            {
                mDiasLaborados = value;
            }
        }

        public double GratificacionBruta
        {
            get
            {
                return mGratificacionBruta;
            }
            set
            {
                mGratificacionBruta = value;
            }
        }

        public double BonoExtraordinario
        {
            get
            {
                return mBonoExtraordinario;
            }
            set
            {
                mBonoExtraordinario = value;
            }
        }

        public double GratificacionNeta
        {
            get
            {
                return mGratificacionNeta;
            }
            set
            {
                mGratificacionNeta = value;
            }
        }

        public double DescuentoRetencionJudicial
        {
            get
            {
                return mDescuentoRetencionJudicial;
            }
            set
            {
                mDescuentoRetencionJudicial = value;
            }
        }

        public double DescuentoImpuesto
        {
            get
            {
                return mDescuentoImpuesto;
            }
            set
            {
                mDescuentoImpuesto = value;
            }
        }

        public double GratificacionPagar
        {
            get
            {
                return mGratificacionPagar;
            }
            set
            {
                mGratificacionPagar = value;
            }
        }
 
        public int Dias
        {
            get
            {
                return mDias;
            }

            set
            {
                mDias = value;
            }
        }
    }

    public class GratificacionDetalle
    {

        private int mIdGratificacionDetalle = 0;
        private int mIdGratificacion = 0;
        private int mAnho = 0;
        private int mMes = 0;
        private string mCodigoEmpleado = "";
        private double mBonoNocturno = 0.0;
        private double mBonoHorasExtras = 0.0;
        private int mDiasCalendario = 0;
        private int mDiasInasistencia = 0;

        public int IdGratificacionDetalle
        {
            get
            {
                return mIdGratificacionDetalle;
            }
            set
            {
                mIdGratificacionDetalle = value;
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

        public double BonoNocturno
        {
            get
            {
                return mBonoNocturno;
            }
            set
            {
                mBonoNocturno = value;
            }
        }

        public double BonoHorasExtras
        {
            get
            {
                return mBonoHorasExtras;
            }
            set
            {
                mBonoHorasExtras = value;
            }
        }

        public int DiasCalendario
        {
            get
            {
                return mDiasCalendario;
            }
            set
            {
                mDiasCalendario = value;
            }
        }

        public int DiasInasistencia
        {
            get
            {
                return mDiasInasistencia;
            }
            set
            {
                mDiasInasistencia = value;
            }
        }

    }
}