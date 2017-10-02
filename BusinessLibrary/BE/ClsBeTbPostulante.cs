using System;
using System.Collections.Generic;

namespace ErpCasino.BusinessLibrary.BE
{

    public class ClsBeTbPostulante : Audit, ICloneable
    {

        private int mIdPostulante = 0;
        private string mNombres = "";
        private string mApellidoPaterno = "";
        private string mApellidoMaterno = "";
        private DateTime mFechaNacimiento = DateTime.Now.AddYears(-18);
        private Record mSexo = null;
        private Record mTipoDocumento = null;
        private string mNumeroDocumento = "";
        private Pais mPaisNacimiento = null;
        private Record mEstadoCivil = null;
        private bool mActivo = false;
        private bool mCandidato = false;
        private Ubigeo mUbigeoNacimiento = null;
        private ClsBeTbPostulanteContacto mContacto = null;
        private List<ClsBeTbPostulanteTelefono> mTelefonos = null;
        private ClsBeTbPostulanteReclutamiento mReclutamiento = null;

        public int IdPostulante
        {
            get
            {
                return mIdPostulante;
            }
            set
            {
                mIdPostulante = value;

                if (mContacto != null)
                {
                    mContacto.IdPostulante = value;
                    for (int i = 0; i < mTelefonos.Count; i++)
                    {
                        mTelefonos[i].IdPostulante = value;
                    }
                }

                if (mReclutamiento != null)
                    mReclutamiento.IdPostulante = value;
            }
        }

        public string Nombres
        {
            get
            {
                return mNombres;
            }
            set
            {
                mNombres = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return mApellidoPaterno;
            }
            set
            {
                mApellidoPaterno = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return mApellidoMaterno;
            }
            set
            {
                mApellidoMaterno = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return mFechaNacimiento;
            }
            set
            {
                mFechaNacimiento = value;
            }
        }

        public Record Sexo
        {
            get
            {
                return mSexo;
            }
            set
            {
                mSexo = value;
            }
        }

        public Record TipoDocumento
        {
            get
            {
                return mTipoDocumento;
            }
            set
            {
                mTipoDocumento = value;
            }
        }

        public string NumeroDocumento
        {
            get
            {
                return mNumeroDocumento;
            }
            set
            {
                mNumeroDocumento = value;
            }
        }

        public Pais PaisNacimiento
        {
            get
            {
                return mPaisNacimiento;
            }
            set
            {
                mPaisNacimiento = value;
            }
        }

        public Record EstadoCivil
        {
            get
            {
                return mEstadoCivil;
            }
            set
            {
                mEstadoCivil = value;
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

        public ClsBeTbPostulanteContacto Contacto
        {
            get
            {
                return mContacto;
            }
            set
            {
                mContacto = value;
            }
        }

        public List<ClsBeTbPostulanteTelefono> Telefonos
        {
            get
            {
                return mTelefonos;
            }
            set
            {
                mTelefonos = value;
            }
        }

        public ClsBeTbPostulanteReclutamiento Reclutamiento
        {
            get
            {
                return mReclutamiento;
            }

            set
            {
                mReclutamiento = value;
            }
        }

        public bool Candidato
        {
            get
            {
                return mCandidato;
            }

            set
            {
                mCandidato = value;
            }
        }

        public Ubigeo UbigeoNacimiento
        {
            get
            {
                return mUbigeoNacimiento;
            }

            set
            {
                mUbigeoNacimiento = value;
            }
        }

        public ClsBeTbPostulante()
        {
            this.Telefonos = new List<ClsBeTbPostulanteTelefono>();
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

    }

}
