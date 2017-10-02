using System;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbCandidatoContratacion : ICloneable
    {

        private int mIdCandidato = 0;
        private DateTime mInduccionFechaInicio = DateTime.Now;
        private DateTime? mInduccionFechaFin = null;
        private bool mInduccion = false;
        private bool mDisciplina = false;
        private bool mInforme = false;
        private bool mDocumentacion = false;
        private string mObservacion = "";

        public int IdCandidato
        {
            get
            {
                return mIdCandidato;
            }
            set
            {
                mIdCandidato = value;
            }
        }
        

        public string Observacion
        {
            get
            {
                return mObservacion;
            }
            set
            {
                mObservacion = value;
            }
        }

        public bool Induccion
        {
            get
            {
                return mInduccion;
            }

            set
            {
                mInduccion = value;
            }
        }

        public bool Disciplina
        {
            get
            {
                return mDisciplina;
            }

            set
            {
                mDisciplina = value;
            }
        }

        public bool Informe
        {
            get
            {
                return mInforme;
            }

            set
            {
                mInforme = value;
            }
        }

        public bool Documentacion
        {
            get
            {
                return mDocumentacion;
            }

            set
            {
                mDocumentacion = value;
            }
        }

        public DateTime InduccionFechaInicio
        {
            get
            {
                return mInduccionFechaInicio;
            }

            set
            {
                mInduccionFechaInicio = value;
            }
        }

        public DateTime? InduccionFechaFin
        {
            get
            {
                return mInduccionFechaFin;
            }

            set
            {
                mInduccionFechaFin = value;
            }
        }

        public ClsBeTbCandidatoContratacion()
        {
        }
        
        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
