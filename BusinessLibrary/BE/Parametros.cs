using System;

namespace ErpCasino.BusinessLibrary.BE
{
    public class Parametros : IDisposable
    {

        private int baseDias = 30;
        private int baseHoras = 8;

        private double sueldoMinimo = 850.0;
        private double asignacionFamiliar = 85.0;
        private double asignacionFamiliarPorcentaje = 10.0;

        private double horarioNocturnoFactor = 1.35; 
        private double horasExtras1Factor = 1.25; 
        private double horasExtras2Factor = 1.35; 
        private double feriadoFactor = 2.00; 

        private double horarioNocturnoPorcentaje = 35.0;
        private double horasExtras1Porcentaje = 25.0;
        private double horasExtras2Porcentaje = 35.0;
        private double feriadoPorcentaje = 100.0;

        private double esSaludFactor = 0.09;
        private double esSaludPorcentaje = 9.0;

        public Parametros()
        {
        }

        public Parametros(double sueldoMinimo)
        {
            this.sueldoMinimo = sueldoMinimo;
            this.asignacionFamiliar = sueldoMinimo / this.asignacionFamiliarPorcentaje;
        }

        public double SueldoMinimo
        {
            get
            {
                return sueldoMinimo;
            }
            set
            {
                sueldoMinimo = value;
                asignacionFamiliar = sueldoMinimo / asignacionFamiliarPorcentaje;
            }
        }

        public double AsignacionFamiliar
        {
            get
            {
                return asignacionFamiliar;
            }
        }

        public double AsignacionFamiliarPorcentaje
        {
            get
            {
                return asignacionFamiliarPorcentaje;
            }
            set
            {
                asignacionFamiliarPorcentaje = value;
                asignacionFamiliar = sueldoMinimo / asignacionFamiliarPorcentaje;
            }
        }

        public double HorarioNocturnoFactor
        {
            get
            {
                return horarioNocturnoFactor;
            }
        }

        public double HorasExtras1Factor
        {
            get
            {
                return horasExtras1Factor;
            }
        }

        public double HorasExtras2Factor
        {
            get
            {
                return horasExtras2Factor;
            }
        }

        public double FeriadoFactor
        {
            get
            {
                return feriadoFactor;
            }
        }

        public double HorarioNocturnoPorcentaje
        {
            get
            {
                return horarioNocturnoPorcentaje;
            }
            set
            {
                horarioNocturnoPorcentaje = value;
                horarioNocturnoFactor = 1 + (horarioNocturnoPorcentaje / 100);
            }
        }

        public double HorasExtras1Porcentaje
        {
            get
            {
                return horasExtras1Porcentaje;
            }
            set
            {
                horasExtras1Porcentaje = value;
                horasExtras1Factor = 1 + (horasExtras1Porcentaje / 100);
            }
        }

        public double HorasExtras2Porcentaje
        {
            get
            {
                return horasExtras2Porcentaje;
            }
            set
            {
                horasExtras2Porcentaje = value;
                horasExtras2Factor = 1 + (horasExtras2Porcentaje / 100);
            }
        }

        public double FeriadoPorcentaje
        {
            get
            {
                return feriadoPorcentaje;
            }
            set
            {
                feriadoPorcentaje = value;
                feriadoFactor = 1 + (feriadoPorcentaje / 100);
            }
        }

        public double EsSaludFactor
        {
            get
            {
                return esSaludFactor;
            }
        }

        public double EsSaludPorcentaje
        {
            get
            {
                return esSaludPorcentaje;
            }
            set
            {
                esSaludPorcentaje = value;
                esSaludFactor = 1 + (esSaludPorcentaje / 100);
            }
        }

        public int BaseDias
        {
            get
            {
                return baseDias;
            }
        }

        public int BaseHoras
        {
            get
            {
                return baseHoras;
            }
        }

        #region Dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        #endregion
    }
}
