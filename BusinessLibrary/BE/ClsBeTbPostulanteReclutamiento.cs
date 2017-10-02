using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulanteReclutamiento : ICloneable
    {

        private int mIdPostulante = 0;
        private string mCargoCurriculum = "";
        private DateTime mFechaRecepcion = DateTime.Now;
        private string mObservacion = "";
        private List<ClsBeTbPostulanteHistorial> mHistorial = null;

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

        public string CargoCurriculum
        {
            get
            {
                return mCargoCurriculum;
            }

            set
            {
                mCargoCurriculum = value;
            }
        }

        public DateTime FechaRecepcion
        {
            get
            {
                return mFechaRecepcion;
            }

            set
            {
                mFechaRecepcion = value;
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

        public List<ClsBeTbPostulanteHistorial> Historial
        {
            get
            {
                return mHistorial;
            }

            set
            {
                mHistorial = value;
            }
        }

        public ClsBeTbPostulanteReclutamiento()
        {
            this.Historial = new List<ClsBeTbPostulanteHistorial>();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
